using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ManualDebug
{
    public class ManualDebugInputBuilder : MonoBehaviour
    {
        [SerializeField] private AbstractManualDebugInput[] _prefabInputs;

        private List<AbstractManualDebugInput> _inputs;

        private void Awake()
        {
            _inputs = new List<AbstractManualDebugInput>();
        }

        public void Build(ManualMethod manualMethod)
        {
            ClearInputs();
            BuildInputs(manualMethod);
        }

        public void ClearInputs()
        {
            foreach (var input in _inputs)
            {
                Destroy(input.gameObject);
            }
            
            _inputs.Clear();
        }

        public void BuildInputs(ManualMethod bind)
        {
            foreach (var parameter in bind.Parameters)
            {
                var prefabInput = _prefabInputs.FirstOrDefault(prefab => prefab.Style == parameter.styleType);
                var input = Instantiate(prefabInput, transform);
                input.Setup(parameter.displayName, parameter.GetDefaultValues());
                _inputs.Add(input);
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