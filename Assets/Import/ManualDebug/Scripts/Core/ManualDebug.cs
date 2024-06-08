using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ManualDebug
{
    public class ManualDebug
    {
        private const BindingFlags FLAGS = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;

        private readonly List<ManualMethod> _methods;
        private readonly List<object> _lazyRegisterContexts;
        private readonly List<IOverrideParameter> _overrideParameters;

        public event Action DirtyContextsEvent;

        public ManualDebug()
        {
            _methods = new List<ManualMethod>();
            _lazyRegisterContexts = new List<object>();

            _overrideParameters = new List<IOverrideParameter>
            {
                new BoolOverride(),
                new PrimitiveOverride(),
                new StringOverride(),
                new EnumOverride(),
                new UnityOverride(),
            };
        }

        public List<string> GetKeys()
        {
            return _methods.Select(bind => bind.Key).ToList();
        }

        public ManualMethod GetBind(string key)
        {
            return _methods.Find(bind => bind.Key == key);
        }

        public void ResolveLazyRegistration()
        {
            RegisterContexts(_lazyRegisterContexts);
            _lazyRegisterContexts.Clear();
        }

        public void LazyRegisterContext(object context)
        {
            _lazyRegisterContexts.Add(context);
        }

        public void LazyRegisterContexts(IEnumerable<object> contexts)
        {
            foreach (var context in contexts)
            {
                LazyRegisterContext(context);
            }
        }

        public void RegisterContext(object context, bool isNotify = false)
        {
            var type = context.GetType();
            
            while (type != null)
            {
                var methods = type.GetMethods(FLAGS).Where(method => method.IsDefined(typeof(ManualDebugButtonAttribute), false));

                foreach (var target in methods)
                {
                    var attribute = target.GetCustomAttribute<ManualDebugButtonAttribute>();

                    var key = !string.IsNullOrEmpty(attribute.alias) ? attribute.alias : $"{type.Name}.{target.Name}";
                    
                    _methods.Add(new ManualMethod(key, target, context, CreateParameters(target, type, context)));
                }

                type = type.BaseType;
            }

            if (isNotify)
            {
                DirtyContextsEvent?.Invoke();
            }
        }

        public void RegisterContexts(IEnumerable<object> contexts, bool isNotify = false)
        {
            foreach (var context in contexts)
            {
                RegisterContext(context);
            }

            if (isNotify)
            {
                DirtyContextsEvent?.Invoke();
            }
        }

        public void UnregisterContext(object context)
        {
            _methods.RemoveAll(manualMethod => manualMethod.Context == context);
        }

        public void Invoke(string key, object[] param = null)
        {
            _methods.Find(manualMethod => manualMethod.Key == key).Invoke(param);
        }

        private List<Parameter> CreateParameters(MethodInfo target, Type contextType, object context)
        {
            var result = new List<Parameter>();
            var param = target.GetParameters();
            var styles = target.GetCustomAttributes<ManualParameterStyleAttribute>().Select(x => x as ManualParameterStyleAttribute).ToList();

            foreach (var parameter in param)
            {
                result.Add(CreateParameter(parameter, contextType, context, styles.FirstOrDefault(data => data.position == parameter.Position)));
            }

            return result;
        }
        
        private Parameter CreateParameter(ParameterInfo parameterInfo, Type contextType, object context, ManualParameterStyleAttribute data = null)
        {
            var type = parameterInfo.ParameterType;

            var parameter = new Parameter
            {
                displayName = parameterInfo.Name,
            };

            foreach (var overrideParameter in _overrideParameters)
            {
                if (overrideParameter.TryOverride(type, parameter))
                {
                    break;
                }
            }

            OverrideParameterByAttributeData(parameter, data, context, contextType);
            
            return parameter;
        }
        
        public void OverrideParameterByAttributeData(Parameter parameter, ManualParameterStyleAttribute data, object context, Type contextType)
        {
            if (data == null)
            {
                return;
            }

            if (parameter.isAllowedOverrideStyle)
            {
                parameter.styleType = data.styleType;   
            }

            if (!string.IsNullOrEmpty(data.defaultValueSetterMethodName))
            {
                var valueSetter = new MethodParameterDefaultValueSetter(data.isСachedValues)
                {
                    setterContext = context,
                    setterMethod = contextType.GetMethod(data.defaultValueSetterMethodName, FLAGS)
                };

                parameter.extraSetter = valueSetter;
                
                return;
            }

            if (data.defaultValues != null)
            {
                parameter.extraSetter = new ParameterDefaultValueSetter(true, data.defaultValues.Select(value => value.ToString()));
            }
        }
    }
}