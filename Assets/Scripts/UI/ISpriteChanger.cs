namespace Assets.Scripts.UI
{
    using UnityEngine;

    public interface ISpriteChanger
    {
        Sprite[] Sprites { get; }
        void ChangeSprite(int index);
        void ChangeNextSprite();
    }
}