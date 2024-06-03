using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ManualDebug
{
    public class ManualDebugInputBuilder : MonoBehaviour
    {
        [SerializeField] private ManualDebugValueTypeBuilderInput _valueTypeInputPrefab;

        private List<AbstractBuilderInput> _inputs;

        private void Awake()
        {
            _inputs = new List<AbstractBuilderInput>();
        }

        public void Build(MethodInfo methodInfo)
        {
            ClearInputs();
            BuildInputs(methodInfo);
        }

        public void ClearInputs()
        {
            foreach (var input in _inputs)
            {
                Destroy(input.gameObject);
            }
        }

        public void BuildInputs(MethodInfo methodInfo)
        {
            var parameterInfos = methodInfo.GetParameters();

            foreach (var parameterInfo in parameterInfos)
            {
                var type = parameterInfo.ParameterType;

                if (type.IsPrimitive || type == typeof(string))
                {
                    var instance = Instantiate(_valueTypeInputPrefab, transform);
                    instance.SetNameParam(parameterInfo.Name);
                    instance.SetConversionType(type);
                    _inputs.Add(instance);
                }

                if (type.IsEnum)
                {
                }
            }
        }

        public object[] GetParam()
        {
            var param = new object[_inputs.Count];

            for (var i = 0; i < _inputs.Count; i++)
            {
                param[i] = _inputs[i].GetParam();
            }

            return param;
        }
    }
}