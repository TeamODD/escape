namespace Assets.Scripts.UI.Options
{
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.UI;

    public class OptionObject : SerializedMonoBehaviour, ISpriteChanger
    {
        [field:SerializeField] protected Image _image;
        [field:SerializeField] public Sprite[] Sprites { get; protected set;}
        private int _index;
        public virtual void ChangeSprite(int index)
        {
            if(_image == null || _index >= Sprites.Length)
            {
                return;
            }
            _index = index;
            _image.sprite = Sprites[_index];
        }
        public virtual void ChangeNextSprite()
        {
            if(_image == null)
            {
                return;
            }
            _index = (_index + 1) % Sprites.Length;
            _image.sprite = Sprites[_index];
        }
    }
}