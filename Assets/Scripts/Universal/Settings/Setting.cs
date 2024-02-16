using UnityEngine;

namespace Settings
{
    public class Setting : ScriptableObject
    {
        [SerializeField] protected string _title;
        public string Title => _title;

        public virtual bool IsMinValue { get; }
        public virtual bool IsMaxValue { get; }

        public virtual void SetNextValue() { }
        public virtual void SetPreviousValue() { }
        public virtual object GetValue() { return default(object); }
        public virtual string GetStringValue() { return string.Empty; }
        public virtual void Load() { }
        public virtual void Apply() { }
    }
}