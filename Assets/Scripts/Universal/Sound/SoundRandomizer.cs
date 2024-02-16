using UnityEngine;

namespace SoundSystem
{
    public class SoundRandomizer : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _clips;

        public void PlayRandomAudioClip()
        {
            int index = Random.Range(0, _clips.Length);
            var clip = _clips[index];
            SoundPlayer.Instance.PlayRandom(clip);
        }
    }
}