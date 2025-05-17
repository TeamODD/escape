namespace Assets.Scripts.Utility.Singletons
{
    using UnityEngine;
    
    public class TitleOptionCanvas : MonoBehaviour
    {
        private static TitleOptionCanvas _instance;
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
        }
    }
}