namespace Assets.Scripts.Utility
{
    using UnityEngine;
    
    public class RectTransformInitializer : MonoBehaviour
    {
        [field:SerializeField] public RectTransform Transform { get; private set; }
        [field:SerializeField] public Vector3 AnchoredPosition { get; private set; }
        public void InitializePosition()
        {
            Transform.anchoredPosition = AnchoredPosition;
        }
    }
}