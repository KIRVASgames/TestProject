using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class UISelectableButton : UIButton
    {
        [SerializeField] private Image selectImage;

        public UnityEvent OnSelect { get; private set; }
        public UnityEvent OnUnSelect { get; private set; }

        public bool CheckInteractive => IsInteractive;

        public override void SetFocus()
        {
            base.SetFocus();

            selectImage.enabled = true;
            OnSelect?.Invoke();
        }

        public override void SetUnFocus()
        {
            base.SetUnFocus();

            selectImage.enabled = false;
            OnUnSelect?.Invoke();
        }
    }
}
