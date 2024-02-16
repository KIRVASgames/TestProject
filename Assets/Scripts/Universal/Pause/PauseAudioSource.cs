using UnityEngine;
using Dependencies;

[RequireComponent(typeof(AudioSource))]
public class PauseAudioSource : MonoBehaviour, IDependency<Pauser>
{
    private AudioSource _audio;

    private Pauser _pauser;
    public void Construct(Pauser pauser) => _pauser = pauser;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();

        _pauser.PauseStateChange += OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        _pauser.PauseStateChange -= OnPauseStateChanged;
    }

    private void OnPauseStateChanged(bool pause)
    {
        if (pause)
            _audio.Stop();

        if (!pause)
            _audio.Play();
    }
}