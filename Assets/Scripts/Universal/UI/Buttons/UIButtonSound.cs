using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(AudioSource))]
    public class UIButtonSound : MonoBehaviour
    {
        [SerializeField] private AudioClip _hover;
        [SerializeField] private AudioClip _click;

        private AudioSource _audio;

        private UIButton[] _buttons;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();

            _buttons = GetComponentsInChildren<UIButton>(true); // true - ищет в том числе в неактивных GameObject

            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].PointerEnter += OnPointerEnter;
                _buttons[i].PointerClick += OnPointerClick;
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].PointerEnter -= OnPointerEnter;
                _buttons[i].PointerClick -= OnPointerClick;
            }
        }

        private void OnPointerEnter(UIButton button)
        {
            _audio.PlayOneShot(_hover);
        }

        private void OnPointerClick(UIButton button)
        {
            _audio.PlayOneShot(_click);
        }
    }
}