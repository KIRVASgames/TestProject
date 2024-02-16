using UnityEngine;
using UnityEngine.Audio;

namespace Settings
{
    [CreateAssetMenu]
    public class AudioMixerFloatSetting : Setting
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private string _nameParametr;

        [SerializeField] private float _minRealValue;
        [SerializeField] private float _maxRealValue;

        [SerializeField] private float _virtualStep;
        [SerializeField] private float _minVirtualValue;
        [SerializeField] private float _maxVirtualValue;

        private float _currentValue = 0;

        public override bool IsMinValue { get => _currentValue == _minRealValue; }
        public override bool IsMaxValue { get => _currentValue == _maxRealValue; }

        public override void SetNextValue()
        {
            AddValue(Mathf.Abs(_maxRealValue - _minRealValue) / _virtualStep);
        }

        public override void SetPreviousValue()
        {
            AddValue(-Mathf.Abs(_maxRealValue - _minRealValue) / _virtualStep);
        }

        public override string GetStringValue()
        {
            return Mathf.Lerp(_minVirtualValue, _maxVirtualValue, (_currentValue - _minRealValue) / (_maxRealValue - _minRealValue)).ToString();
        }

        public override object GetValue()
        {
            return _currentValue;
        }

        private void AddValue(float value)
        {
            _currentValue += value;
            _currentValue = Mathf.Clamp(_currentValue, _minRealValue, _maxRealValue);
        }

        public override void Apply()
        {
            _audioMixer.SetFloat(_nameParametr, _currentValue);

            Save();
        }

        public override void Load()
        {
            _currentValue = PlayerPrefs.GetFloat(_title, 0);
        }

        private void Save()
        {
            PlayerPrefs.SetFloat(_title, _currentValue);
        }
    }
}