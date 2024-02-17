using UnityEngine;

namespace SoundSystem
{
    public class SoundHook : MonoBehaviour
    {
        public Sound Sound { get; private set; } 

        public void Play() { Sound.Play(); }
    }
}