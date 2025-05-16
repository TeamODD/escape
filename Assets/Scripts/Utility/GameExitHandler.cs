namespace Assets.Scripts.Utility
{
    using UnityEngine;
    
    public class GameExitHandler : MonoBehaviour
    {
        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}