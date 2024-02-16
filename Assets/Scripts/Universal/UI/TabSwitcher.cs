using UnityEngine;

namespace UI
{
    public class TabSwitcher : MonoBehaviour
    {
        [SerializeField] private Tab[] _tabs;

        private Tab _currentTab;
        private Tab _previousTab;

        #region UnityEvents
        private void Start()
        {
            if (_tabs.Length > 0)
            {
                var homeTab = _tabs[0];
                _currentTab = homeTab;

                foreach (var tab in _tabs)
                {
                    tab.OnClickEvent += DoOnClickAction;

                    if (tab == homeTab)
                        Open(tab);
                    else
                        Close(tab);
                }
            }
            else
                Debug.LogWarning("Tab[] array is empty!");    
        }

        private void OnDestroy()
        {
            foreach (var tab in _tabs)
                tab.OnClickEvent -= DoOnClickAction;
        }
        #endregion

        public void OpenPreviousTab()
        {
            Close(_currentTab);
            Open(_previousTab);
        }

        private void Open(Tab tab)
        {
            _previousTab = _currentTab;
            _currentTab = tab;
            tab.SetActive(true);
        }

        private void Close(Tab tab)
        {
            tab.SetActive(false);
        }

        private void DoOnClickAction(Tab tab)
        {
            Open(tab);
            Close(_previousTab);
        }
    }
}