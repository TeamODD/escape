namespace Assets.Scripts.Animators.FadableAdapters
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ImageAdapter : IFadableAdapter
    {
        [SerializeField] Image _image;

        public float Value
        {
            get => _image.color.a;
            set
            {
                Color color = _image.color;
                color.a = value;
                _image.color = color;
            }
        }
    }
}