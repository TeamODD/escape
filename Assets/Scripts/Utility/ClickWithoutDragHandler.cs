namespace Assets.Scripts.Utility
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    public class ClickWithoutDragHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler
    {
        [field:SerializeField] public UnityEvent OnClickWithoutDrag { get; private set; }
        private bool _wasDragged = false;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _wasDragged = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _wasDragged = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_wasDragged)
            {
                OnClickWithoutDrag.Invoke();
            }
        }
    }
}