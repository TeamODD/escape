namespace Assets.Scripts.Escape.Inventory
{
    using Dialogue;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class ItemData : SerializedMonoBehaviour
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] private bool _isAcquired;
        public bool IsAcquired
        {
            get => _isAcquired;
            set
            {
                _isAcquired = value;
                AcquiredMappingItemData();
            }
        }
        [field: SerializeField] public DialogueData Description { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public ItemData MappingItemData { get; private set; }
        public void Start()
        {
            InventoryManager.Instance.ItemDictionary[Name] = this;
        }
        private void AcquiredMappingItemData()
        {
            if (!MappingItemData._isAcquired)
            {
                MappingItemData._isAcquired = true;
            }
        }
    }        
}
