namespace Assets.Scripts.Utility
{
    using UnityEngine;
    
    public class MousePointerBinder : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private void Start()
        {
            if(_camera == null)
            {
                _camera = Camera.main;
            }
        }
        private void Update()
        {
            Vector2 mouseScreenPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouseScreenPosition;
        }
    }
}