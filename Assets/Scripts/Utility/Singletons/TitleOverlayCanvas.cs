namespace Assets.Scripts.Utility.Singletons
{
    using UnityEngine;
    
    public class TitleOverlayCanvas : MonoBehaviour
    {
        private static TitleOverlayCanvas _instance;
        private void Awake()
        {
            if( _instance != null && _instance != this )
            {
                Destroy(gameObject);
            }
            _instance = this;
        }
    }
}