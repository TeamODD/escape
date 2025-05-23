namespace Assets.Scripts.Utility
{
    using UnityEngine;
    
    public class OrthographicSizeScaler : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _referenceWidth = 1920f;
        [SerializeField] private float _referenceHeight = 1080f;
        [SerializeField] private float _referenceOrthographicSize = 5.4f;

        public void ApplyResize()
        {
            if (!_camera.orthographic)
            {
                return;
            }

            float baseAspect = _referenceWidth / _referenceHeight;
            float currentAspect = (float)Screen.width / Screen.height;

            if (baseAspect < currentAspect)
            {
                return;
            }

            _camera.orthographicSize = _referenceOrthographicSize * (baseAspect / currentAspect);
        }

        private void Start()
        {
            ApplyResize();
        }
    }
}