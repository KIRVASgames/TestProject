using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ImageAlphaModifier : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        [Space]
        
        [SerializeField][Range(0, 255)] private float _targetValue = 255.0f;
        
        [SerializeField][Range(0, 100)] private float _speedRate = 100.0f;

        public event Action OnAlphaAmountComplete;

        const float MinValue = 0.0f;
        const float MaxValue = 255.0f;

        private float _currentValue;
        private bool _eventInvoked = false;

        #region UnityEvents
        private void Awake()
        {
            _currentValue = MinValue;
            enabled = false;
        }

        private void Update()
        {
            if (_currentValue >= _targetValue)
            {
                OnAlphaAmountComplete?.Invoke();
                _eventInvoked = true;
            }

            if (_currentValue >= MaxValue || _eventInvoked)
                enabled = false;

            _currentValue += _speedRate * Time.deltaTime;
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _currentValue / MaxValue);
        }
        #endregion

        public void Activate()
        {
            _currentValue = MinValue;
            enabled = true;
        }
    }
}