using UnityEngine;

/// <summary>
/// ������� ��������, ��� �� ����� ���� ��� ���������� � �����.
/// </summary>
/// <typeparam name="T"></typeparam>
[DisallowMultipleComponent]
public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Singleton")]
    [SerializeField] private bool _isNotDestroyableOnLoad;

    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("MonoSingleton: object of type already exists, instance will be destroyed = " + typeof(T).Name);
            Destroy(this);
            return;
        }

        Instance = this as T;

        if (_isNotDestroyableOnLoad)
            DontDestroyOnLoad(gameObject);
    }
}