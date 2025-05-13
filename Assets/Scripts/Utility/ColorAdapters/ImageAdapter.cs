namespace Assets.Scripts.Utility.ColorAdapters
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ImageAdapter : IColorAdapter
    {
        [SerializeField] private Image _Image;
        public Color Color
        {
            get => _Image.color;
            set
            {
                _Image.color = value;
            }
        }
    }
}