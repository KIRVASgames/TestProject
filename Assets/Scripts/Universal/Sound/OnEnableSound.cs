using UnityEngine;

namespace SoundSystem
{
    public class OnEnableSound : MonoBehaviour
    {
        [SerializeField] private Sound _sound;

        private void OnEnable()
        {
            _sound.Play();
        }
    }
}