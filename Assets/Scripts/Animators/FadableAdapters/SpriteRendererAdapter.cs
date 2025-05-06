namespace Assets.Scripts.Animators.FadableAdapters
{
    using UnityEngine;

    public class SpriteRendererAdapter : IFadableAdapter
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public float Value
        {
            get => _spriteRenderer.color.a;
            set
            {
                Color color = _spriteRenderer.color;
                color.a = value;
                _spriteRenderer.color = color;
            }
        }
    }
}