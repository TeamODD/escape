namespace Assets.Scripts.Escape.Zoom
{
    using Assets.Scripts.Escape.Inventory;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class ZoomManager : SerializedMonoBehaviour
    {
        [field: SerializeField] private Image _zoomImage;
        [field: SerializeField] public UnityEvent OnImageEnabled { get; private set; }
        [field: SerializeField] public UnityEvent OnImageDisabled { get; private set; }
        public ObjectData ObjectData { get; private set; }
        public void SetZoomImage(Sprite sprite)
        {
            _zoomImage.sprite = sprite;
            OnImageEnabled.Invoke();
        }
        public void SetObjectData(ObjectData data)
        {
            ObjectData = data;
        }
        public void DeactivateZoomImage()
        {
            ObjectData = null;
            OnImageDisabled.Invoke();
        }
    }        
}
