namespace Assets.Scripts.UI.Options
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class OptionManager : SerializedMonoBehaviour
    {
        public static OptionManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        [field:SerializeField] private OptionObject[] _optionObjects;
        public void ChangeSprites()
        {
            foreach (var option in _optionObjects)
            {
                option.ChangeNextSprite();
            }
        }
        public void ChangeSprites(int index)
        {
            foreach (var option in _optionObjects)
            {
                option.ChangeSprite(index);
            }
        }
    }
}