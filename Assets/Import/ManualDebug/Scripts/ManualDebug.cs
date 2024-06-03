using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ManualDebug
{
    public class ManualDebug
    {
        private const BindingFlags FLAGS = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;

        private readonly Dictionary<string, ContextMethodBind> _contexts;

        public event Action RefreshEvent;

        public ManualDebug()
        {
            _contexts = new Dictionary<string, ContextMethodBind>();
        }

        public List<string> GetKeys => _contexts.Keys.ToList();

        public void AddContext(object receiver, bool isNotify = false)
        {
            var type = receiver.GetType();
            
            while (type != null)
            {
                var methods = type.GetMethods(FLAGS).Where(method => method.IsDefined(typeof(ManualDebugButtonAttribute), false));

                foreach (var methodInfo in methods)
                {
                    _contexts.Add($"{type.Name}.{methodInfo.Name}", new ContextMethodBind(methodInfo, receiver));
                }

                type = type.BaseType;
            }

            if (isNotify)
            {
                RefreshEvent?.Invoke();
            }
        }

        public void AddContexts(IEnumerable<object> receivers, bool isNotify = false)
        {
            foreach (var receiver in receivers)
            {
                AddContext(receiver);
            }

            if (isNotify)
            {
                RefreshEvent?.Invoke();
            }
        }

        public MethodInfo GetMethod(string key) => _contexts[key].methodInfo;

        public void Invoke(string key, object[] param = null)
        {
            var value = _contexts[key];

            value.methodInfo.Invoke(value.context, param);
        }
    }
}