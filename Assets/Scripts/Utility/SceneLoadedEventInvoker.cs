namespace Assets.Scripts.Utility
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.SceneManagement;

    public class SceneLoadedEventInvoker : MonoBehaviour
    {
        [field:SerializeField] public UnityEvent OnSceneLoadedEvent { get; private set; }
        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        {
            OnSceneLoadedEvent.Invoke();
        }
    }
}