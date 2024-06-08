using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ManualDebug
{
    public class ManualDebug
    {
        private const BindingFlags FLAGS = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;

        private readonly List<MethodBind> _methods;

        public event Action RefreshEvent;

        public ManualDebug()
        {
            _methods = new List<MethodBind>();
        }

        public List<string> GetKeys => _methods.Select(bind => bind.Key).ToList();

        public MethodBind GetBind(string key) => _methods.Find(bind => bind.Key == key);

        public void RegisterContext(object context, bool isNotify = false)
        {
            var type = context.GetType();
            
            while (type != null)
            {
                var methods = type.GetMethods(FLAGS).Where(method => method.IsDefined(typeof(ManualDebugButtonAttribute), false));

                foreach (var target in methods)
                {
                    _methods.Add(new MethodBind($"{type.Name}.{target.Name}", target, context, CreateParameters(target, type, context)));
                }

                type = type.BaseType;
            }

            if (isNotify)
            {
                RefreshEvent?.Invoke();
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
                RefreshEvent?.Invoke();
            }
        }

        public void Invoke(string key, object[] param = null)
        {
            _methods.Find(bind => bind.Key == key).Invoke(param);
        }

        private List<Parameter> CreateParameters(MethodInfo target, Type contextType, object context)
        {
            var result = new List<Parameter>();
            var param = target.GetParameters();
            var styles = target.GetCustomAttributes(typeof(ManualParameterStyleAttribute), false).Select(x => x as ManualParameterStyleAttribute).ToList();

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
            
            if (type.IsPrimitive || type == typeof(string))
            {
                parameter.converter = new PrimitiveConverter(type);
                
                if (type == typeof(bool))
                {
                    parameter.styleType = ManualParamStyleType.Toggle;
                }
                else
                {
                    parameter.styleType = ManualParamStyleType.Primitive;
                }
            }

            if (type.IsEnum)
            {
                parameter.converter = new EnumConverter(type);
                parameter.styleType = ManualParamStyleType.Dropdown;

                parameter.setter = new ParameterDefaultValueSetter
                {
                    isСachedValues = true,
                    setterValues = Enum.GetNames(type),
                };
            }
            
            if (data != null)
            {
                parameter.styleType = data.styleType;

                if (!string.IsNullOrEmpty(data.defaultValueSetterMethodName))
                {
                    var valueSetter = new ParameterDefaultValueSetter
                    {
                        isСachedValues = data.isСachedValues,
                        setterContext = context,
                        setterMethod = contextType.GetMethod(data.defaultValueSetterMethodName, FLAGS)
                    };

                    parameter.setter = valueSetter;
                }
                else if (data.defaultValues != null)
                {
                    var valueSetter = new ParameterDefaultValueSetter
                    {
                        isСachedValues = true,
                        setterValues = data.defaultValues.Select(value => value.ToString())
                    };

                    parameter.setter = valueSetter;
                }
            }
            
            return parameter;
        }
    }
}