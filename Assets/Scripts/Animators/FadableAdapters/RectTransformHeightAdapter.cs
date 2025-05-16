namespace Assets.Scripts.Animators.FadableAdapters
{
    using UnityEngine;

    public class RectTransformHeightAdapter : IFadableAdapter
    {
        [SerializeField] private RectTransform _rectTransform;
        public float Value
        {
            get => _rectTransform.sizeDelta.y;
            set
            {
                _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, value);
            }
        }
    }
}