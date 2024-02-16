using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ImageFiller : MonoBehaviour
    {
        [SerializeField] private Image _image;

        [Space]

        [SerializeField][Range(0, 1)] private float _speedRate = 0.75f;

        public event Action OnFillAmountComplete;

        const float MinValue = 0.0f;
        const float MaxValue = 1.0f;

        #region UnityEvents
        private void Awake()
        {
            _image.fillAmount = MinValue;
            enabled = false;
        }

        private void Update()
        {
            _image.fillAmount += _speedRate * Time.deltaTime;

            if (_image.fillAmount >= MaxValue)
            {
                OnFillAmountComplete?.Invoke();
                enabled = false;
            }
        }
        #endregion

        public void Activate()
        {
            _image.fillAmount = MinValue;
            enabled = true;
        }
    }
}