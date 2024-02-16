using UnityEngine;

namespace Settings
{
    [CreateAssetMenu]
    public class ResolutionSetting : Setting
    {
        [SerializeField]
        private Vector2Int[] _avaliableResolutions = new Vector2Int[]
        {
        new Vector2Int(800, 600),
        new Vector2Int(1024, 768),
        new Vector2Int(1280, 720),
        new Vector2Int(1600, 900),
        new Vector2Int(1920, 1080),
        };

        private int _currentResolutionIndex = 0;

        public override bool IsMinValue { get => _currentResolutionIndex == 0; }
        public override bool IsMaxValue { get => _currentResolutionIndex == _avaliableResolutions.Length - 1; }

        public override void SetNextValue()
        {
            if (!IsMaxValue)
            {
                _currentResolutionIndex++;
            }
        }

        public override void SetPreviousValue()
        {
            if (!IsMinValue)
            {
                _currentResolutionIndex--;
            }
        }

        public override object GetValue()
        {
            return _avaliableResolutions[_currentResolutionIndex];
        }

        public override string GetStringValue()
        {
            return _avaliableResolutions[_currentResolutionIndex].x + "x" + _avaliableResolutions[_currentResolutionIndex].y;
        }

        public override void Apply()
        {
            Screen.SetResolution(_avaliableResolutions[_currentResolutionIndex].x, _avaliableResolutions[_currentResolutionIndex].y, true); // можно вкл./выкл. полноэкранный режим

            Save();
        }

        public override void Load()
        {
            _currentResolutionIndex = PlayerPrefs.GetInt(_title, _avaliableResolutions.Length - 1);
        }

        private void Save()
        {
            PlayerPrefs.SetInt(_title, _currentResolutionIndex);
        }
    }
}