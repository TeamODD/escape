namespace Assets.Scripts.Utility
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    public class UIDragMover : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [field:SerializeField] public UnityEvent<PointerEventData> OnBeginDragEvent { get; private set; }
        [field:SerializeField] public UnityEvent<PointerEventData> OnDragEvent { get; private set; }
        [field:SerializeField] public UnityEvent<PointerEventData> OnEndDragEvent { get; private set; }
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Canvas _canvas;
        private Vector2 _initialAnchoredPosition;
        private Vector2 _dragOffset;

        public void OnBeginDrag(PointerEventData eventData)
        {
            // 마우스 눌렀을 때 위치 기억
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out var localMousePos);

            _dragOffset = _rectTransform.anchoredPosition - localMousePos;

            OnBeginDragEvent.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out var localPoint))
            {
                _rectTransform.anchoredPosition = localPoint + _dragOffset;
            }

            OnDragEvent.Invoke(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndDragEvent.Invoke(eventData);
            _rectTransform.anchoredPosition = _initialAnchoredPosition;
        }
    }
}