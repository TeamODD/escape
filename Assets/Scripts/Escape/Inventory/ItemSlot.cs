namespace Assets.Scripts.Escape.Inventory
{
    using UnityEngine;
    using UnityEngine.UI;
    using Sirenix.OdinInspector;
    using Assets.Scripts.Escape.Dialogue;

    public class ItemSlot : SerializedMonoBehaviour
    {
        [field: SerializeField] public Image ItemImage { get; private set; }
        [SerializeField] private Image _borderImage;
        [SerializeField] private Sprite _realityBorderSprite;
        [SerializeField] private Sprite _dreamBorderSprite;
        [SerializeField] private ItemObject _itemObject;
        private ItemData _itemData;
        public ItemData ItemData
        {
            get => _itemData;
            set
            {
                if (value == null)
                {
                    ItemImage.gameObject.SetActive(false);
                    return;
                }
                _itemData = value;
                _itemObject.ItemData = value;
                ItemImage.sprite = value.Sprite;
                ItemImage.SetNativeSize();
                ItemImage.gameObject.SetActive(value.IsAcquired);
            }
        }
        private SceneState _state;
        public SceneState State
        {
            get => _state;
            set
            {
                _state = value;
                if (value == SceneState.Reality)
                {
                    _borderImage.sprite = _realityBorderSprite;
                }
                else
                {
                    _borderImage.sprite = _dreamBorderSprite;
                }
            }
        }
        public void InitializeState()
        {
            State = SceneState.Reality;
        }

        public void PlayDialogue()
        {
            if (_itemData == null)
            {
                return;
            }
            DialogueController.Instance.PlayDialogue(_itemData.Description);
        }
    }
}
