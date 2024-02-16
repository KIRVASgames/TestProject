using UnityEngine;
using UnityEngine.SceneManagement;
using Dependencies;

namespace SoundSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour, IDependency<Pauser>
    {
        [SerializeField] private bool _isEnabled;
        [SerializeField] private bool _inRandomOrder;
        [SerializeField] private int _currentTrackIndex;
        [SerializeField] private AudioClip[] _audioTracks;

        private Pauser _pauser;
        public void Construct(Pauser pauser) => _pauser = pauser;

        private AudioSource _audioSource;

        private int _currentSceneIndex;

        private void Start()
        {
            _pauser.PauseStateChange += OnPauseStateChanged;
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;

            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _audioTracks[_currentTrackIndex];
            _audioSource.Play();

            if (_inRandomOrder) PlayRandom();
        }

        private void OnDestroy()
        {
            _pauser.PauseStateChange -= OnPauseStateChanged;
            SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;
        }

        private void OnPauseStateChanged(bool value)
        {
            if (value)
                TurnOff();
            else
                TurnOn();
        }

        private void SceneManager_activeSceneChanged(Scene previousActiveScene, Scene newActiveScene)
        {
            if (SceneManager.GetActiveScene().buildIndex != _currentSceneIndex)
            {
                TurnOn();
                PlayRandom();
                _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            }
        }

        private void Update()
        {
            if (SceneManager.GetActiveScene().name == "main_menu" ||
                SceneManager.GetActiveScene().name == "start_screen")
                TurnOff();

            if (_isEnabled)
            {
                if (!_audioSource.isPlaying)
                    PlayNext();

                if (Input.GetKeyDown(KeyCode.RightShift))
                    PlayRandom();

                if (Input.GetKeyDown(KeyCode.LeftShift))
                    PlayNext();

                if (Input.GetKeyDown(KeyCode.RightControl))
                    TurnOff();
            }
            else if (!_isEnabled && Input.GetKeyDown(KeyCode.RightControl))
                TurnOn();
        }

        private void Shuffle(AudioClip[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                AudioClip temp = array[i];
                int randomIndex = Random.Range(i, array.Length);
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }

        #region Public API
        public void TurnOn()
        {
            _isEnabled = true;
            _audioSource.Play();
        }

        public void TurnOff()
        {
            _isEnabled = false;
            _audioSource.Pause();
        }

        public void PlayRandom()
        {
            Shuffle(_audioTracks);
            _audioSource.clip = _audioTracks[0];
            _audioSource.Play();
        }

        public void PlayNext()
        {
            _currentTrackIndex++;
            if (_currentTrackIndex >= _audioTracks.Length)
            {
                _currentTrackIndex = 0;
            }
            _audioSource.clip = _audioTracks[_currentTrackIndex];
            _audioSource.Play();
        }
        #endregion
    }
}