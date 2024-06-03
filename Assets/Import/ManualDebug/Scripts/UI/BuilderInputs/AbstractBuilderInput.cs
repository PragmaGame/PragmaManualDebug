using TMPro;
using UnityEngine;

namespace ManualDebug
{
    public abstract class AbstractBuilderInput : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameParam;

        private string _nameTemplate;
        
        public abstract object GetParam();

        protected virtual void Awake()
        {
            _nameTemplate = _nameParam.text;
        }

        public void SetNameParam(string value)
        {
            _nameParam.text = string.Format(_nameTemplate, value);
        }
    }
}