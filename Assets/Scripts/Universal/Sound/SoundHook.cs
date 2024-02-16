using UnityEngine;

namespace SoundSystem
{
    public class SoundHook : MonoBehaviour
    {
        public Sound _sound { get; private set; } 

        public void Play() { _sound.Play(); }
    }
}