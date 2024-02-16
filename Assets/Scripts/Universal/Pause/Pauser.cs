using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Pauser : MonoBehaviour
{
    public event UnityAction<bool> PauseStateChange;

    private bool _isPause;
    public bool IsPause => _isPause;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneManager_sceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneManager_sceneLoaded;
    }

    private void OnSceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UnPause();
    }

    public void ChangePauseState()
    {
        if (_isPause)
            UnPause();
        else
            Pause();
    }

    public void Pause()
    {
        if (_isPause) return;

        Time.timeScale = 0;
        _isPause = true;
        PauseStateChange?.Invoke(_isPause);
    }

    public void UnPause()
    {
        if (!_isPause) return;

        Time.timeScale = 1;
        _isPause = false;
        PauseStateChange?.Invoke(_isPause);
    }
}