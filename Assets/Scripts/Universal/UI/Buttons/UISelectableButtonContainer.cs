using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UISelectableButtonContainer : MonoBehaviour
    {
        public enum LayoutType
        {
            Vertical,
            Horizontal,
            Grid
        }

        [SerializeField] private LayoutType _layoutType;
        public LayoutType Type => _layoutType;

        [SerializeField] private bool _isSetAuto = true;

        [SerializeField] private Transform _buttonContainer;

        public bool Interactive { get; private set; } = true;
        public void SetInteractive(bool interactive) => Interactive = interactive;

        private UISelectableButton[] _buttons;

        private int _selectButtonIndex = 0;

        private int _constraintCount;
        public int ConstraintCount => _constraintCount;

        private static int MinInteractibleButtonsAmount = 2;

        private void Start()
        {
            if (_isSetAuto)
                SetLayoutType();

            _buttons = _buttonContainer.GetComponentsInChildren<UISelectableButton>();

            if (_buttons == null)
            {
                Debug.Log("Buttons list is empty");
            }
            else
            {
                for (int i = 0; i < _buttons.Length; i++)
                {
                    _buttons[i].PointerEnter += OnPointerEnter;
                }

                if (!Interactive) return;

                _buttons[_selectButtonIndex].SetFocus();
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].PointerEnter -= OnPointerEnter;
            }
        }

        private void OnPointerEnter(UIButton button)
        {
            SelectButton(button);
        }

        private void SetLayoutType()
        {
            var layout = _buttonContainer.GetComponent<LayoutGroup>();

            if (layout is HorizontalLayoutGroup)
                _layoutType = LayoutType.Horizontal;

            if (layout is VerticalLayoutGroup)
                _layoutType = LayoutType.Vertical;

            if (layout is GridLayoutGroup)
            {
                _layoutType = LayoutType.Grid;

                var gridLayout = layout.GetComponent<GridLayoutGroup>();
                _constraintCount = gridLayout.constraintCount;
            }
        }

        private void SelectButton(UIButton button)
        {
            if (!Interactive) return;

            _buttons[_selectButtonIndex].SetUnFocus();

            for (int i = 0; i < _buttons.Length; i++)
            {
                if (button == _buttons[i])
                {
                    _selectButtonIndex = i;
                    button.SetFocus();
                    break;
                }
            }
        }

        private int InteractibleButtonsAmount()
        {
            int amount = 0;

            for (int i = 0; i < _buttons.Length; i++)
            {
                if (_buttons[i].CheckInteractive)
                    amount++;
            }

            return amount;
        }

        public void SelectNext()
        {
            if (InteractibleButtonsAmount() < MinInteractibleButtonsAmount) return;

            List<UISelectableButton> nextButtons = new();

            int focusIndex = 0;

            for (int i = 0; i < _buttons.Length; i++)
            {
                if (_buttons[i].Focus)
                {
                    nextButtons.Add(_buttons[i]);
                    focusIndex = i;
                    break;
                }
            }

            for (int j = focusIndex + 1; j < _buttons.Length; j++)
            {
                if (_buttons[j].CheckInteractive)
                    nextButtons.Add(_buttons[j]);
            }

            for (int k = 0; k < focusIndex; k++)
            {
                if (_buttons[k].CheckInteractive)
                    nextButtons.Add(_buttons[k]);
            }

            nextButtons[0].SetUnFocus();
            nextButtons[1].SetFocus();
        }

        public void SelectPrevious()
        {
            if (InteractibleButtonsAmount() < MinInteractibleButtonsAmount) return;

            List<UISelectableButton> previousButtons = new();

            int focusIndex = 0;

            for (int i = 0; i < _buttons.Length; i++)
            {
                if (_buttons[i].Focus)
                {
                    previousButtons.Add(_buttons[i]);
                    focusIndex = i;
                    break;
                }
            }

            for (int j = focusIndex - 1; j >= 0; j--)
            {
                if (_buttons[j].CheckInteractive)
                    previousButtons.Add(_buttons[j]);
            }

            for (int k = _buttons.Length - 1; k > focusIndex; k--)
            {
                if (_buttons[k].CheckInteractive)
                    previousButtons.Add(_buttons[k]);
            }

            previousButtons[0].SetUnFocus();
            previousButtons[1].SetFocus();
        }
    }
}