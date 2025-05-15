namespace Assets.Scripts.UI.Options
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class OptionManager : SerializedMonoBehaviour
    {
        [field:SerializeField] private OptionObject[] _optionObjects;
        public void ChangeSprites()
        {
            foreach (var option in _optionObjects)
            {
                option.ChangeNextSprite();
            }
        }
    }
}