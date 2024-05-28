using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DebugPanel
{
    public class ManualDebug
    {
        private const BindingFlags FLAGS = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;

        private Dictionary<string, ButtonInfo> _map;

        public event Action RefreshEvent;

        public ManualDebug()
        {
            _map = new Dictionary<string, ButtonInfo>();
        }

        public List<string> GetKeys => _map.Keys.ToList();

        public void AddReceiver(object receiver, bool isNotify = false)
        {
            var type = receiver.GetType();
            
            while (type != null)
            {
                var methods = type.GetMethods(FLAGS).Where(method => method.IsDefined(typeof(ManualDebugButtonAttribute), false));

                foreach (var methodInfo in methods)
                {
                    _map.Add($"{type.Name}.{methodInfo.Name}", new ButtonInfo(methodInfo, receiver));
                }

                type = type.BaseType;
            }

            if (isNotify)
            {
                RefreshEvent?.Invoke();
            }
        }

        public void AddReceivers(IEnumerable<object> receivers, bool isNotify = false)
        {
            foreach (var receiver in receivers)
            {
                AddReceiver(receiver);
            }

            if (isNotify)
            {
                RefreshEvent?.Invoke();
            }
        }

        public void Invoke(string key, object[] param = null)
        {
            var value = _map[key];

            value.methodInfo.Invoke(value.receiver, param);
        }
    }
}