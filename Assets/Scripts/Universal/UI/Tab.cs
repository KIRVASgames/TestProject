using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Tab : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasPanel;

        [SerializeField] private Button _button;

        [SerializeField] private Image _icon;

        [SerializeField] private Image _activeIcon;

        public event Action<Tab> OnClickEvent;

        #region UnityEvents
        private void Start()
        {
            _button.onClick.AddListener(DoOnClickEvent);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(DoOnClickEvent);
        }
        #endregion

        public void SetActive(bool value)
        {
            _button.interactable = !value;
            _icon.enabled = !value;
            _activeIcon.enabled = value;
            _canvasPanel.SetActive(value);
        }

        private void DoOnClickEvent()
        {
            OnClickEvent?.Invoke(this);
        }
    }
}