using UnityEngine;

namespace SoundSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : SingletonBase<SoundPlayer>
    {
        [SerializeField] private SoundsAsset _soundProperties;
        
        [SerializeField] private AudioClip[] _backroundMusicClips;
        
        [SerializeField] private bool _isInRandomOrder;

        private AudioSource _audioSource;

        private int _randomIndex;

        private new void Awake()
        {
            base.Awake();
            _audioSource = GetComponent<AudioSource>();

            if (_isInRandomOrder)
            {
                _randomIndex = Random.Range(0, _backroundMusicClips.Length);
            }
            else _randomIndex = 0;

            Instance._audioSource.clip = _backroundMusicClips[_randomIndex];

            for (int i = 0; i < _backroundMusicClips.Length; i++)
            {
                Instance._audioSource.Play();
            }
        }

        public void Play(Sound sound)
        {
            _audioSource.PlayOneShot(_soundProperties[sound]);
        }

        public void PlayRandom(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}