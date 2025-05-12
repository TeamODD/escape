namespace Assets.Scripts.Utility.Scene
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private SceneID _sceneID;
        public void LoadScene()
        {
            SceneManager.LoadScene((int)_sceneID);
        }
    }
}