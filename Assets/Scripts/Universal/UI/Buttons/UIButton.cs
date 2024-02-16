using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI
{
    public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] protected bool IsInteractive;

        private bool _focus = false;
        public bool Focus => _focus;

        public UnityEvent OnButtonClicked { get; private set; }

        public event UnityAction<UIButton> PointerEnter;
        public event UnityAction<UIButton> PointerExit;
        public event UnityAction<UIButton> PointerClick;

        public virtual void SetFocus()
        {
            if (!IsInteractive) return;

            _focus = true;
        }

        public virtual void SetUnFocus()
        {
            if (!IsInteractive) return;

            _focus = false;
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (!IsInteractive) return;

            PointerEnter?.Invoke(this);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            if (!IsInteractive) return;

            PointerExit?.Invoke(this);
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (!IsInteractive) return;

            PointerClick?.Invoke(this);
            OnButtonClicked?.Invoke();
        }
    }
}