namespace Assets.Scripts.UI.Options
{
    using UnityEngine;
    
    public class OptionToggleButton : OptionObject
    {
        [field:SerializeField] private Sprite[] RealitySprites;
        [field:SerializeField] private Sprite[] DreamSprites;
        public override void ChangeNextSprite()
        {
            if(Sprites == RealitySprites)
            {
                Sprites = DreamSprites;
            }
            else
            {
                Sprites = RealitySprites;
            }
            _image.sprite = Sprites[0];
        }
        public void ChangeToggleSpriteOn()
        {
            _image.sprite = Sprites[1];
        }
        public void ChangeToggleSpriteOff()
        {
            _image.sprite = Sprites[0];
        }
    }
}