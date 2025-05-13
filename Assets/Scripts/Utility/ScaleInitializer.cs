namespace Assets.Scripts.Utility
{
    using UnityEngine;

    public class ScaleInitializer : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Vector3 _scale;
        public void InitializeScale()
        {
            _transform.localScale = _scale;
        }
    }
}