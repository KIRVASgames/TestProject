using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public event UnityAction OnTimerExpired;

    [SerializeField] private float _time;

    private float _value;
    public float Value => _value;

    private void Start()
    {
        _value = _time;
    }

    private void Update()
    {
        _value -= Time.deltaTime;

        if (_value <= 0)
        {
            enabled = false;
            OnTimerExpired?.Invoke();
        }
    }
}