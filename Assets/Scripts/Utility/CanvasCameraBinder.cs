namespace Assets.Scripts.Utility
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class CanvasCameraBinder : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        private void Awake()
        {
            if(_canvas == null)
            {
                _canvas = GetComponent<Canvas>();
            }
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        {
            if (_canvas == null)
            {
                return;
            }
            _canvas.worldCamera = Camera.main;
        }
    }
}