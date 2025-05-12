namespace Assets.Scripts.Utility
{
    using UnityEngine;
    using Sirenix.OdinInspector;
    using ColorAdapters;

    public class ColorInitializer : SerializedMonoBehaviour
    {
        [Tooltip("색 초기화 대상입니다.")]
        [SerializeField] private IColorAdapter _Adatper;
        [SerializeField] private Color _initialColor;
        public void InitializeColor()
        {
            _Adatper.Color = _initialColor;
        }
    }
}