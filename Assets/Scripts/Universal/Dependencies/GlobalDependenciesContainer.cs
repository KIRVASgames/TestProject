using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dependencies
{
    public class GlobalDependenciesContainer : Dependency
    {
        [SerializeField] private Pauser _pauser;

        private static GlobalDependenciesContainer Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        protected override void BindAll(MonoBehaviour monoBehaviourInScene)
        {
            Bind<Pauser>(_pauser, monoBehaviourInScene);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            FindAllObjectsToBind();
        }
    }
}