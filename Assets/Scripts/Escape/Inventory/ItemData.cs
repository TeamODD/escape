namespace Assets.Scripts.Escape.Inventory
{
    using Dialogue;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class ItemData : SerializedMonoBehaviour
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public bool IsAcquired { get; set; }
        [field: SerializeField] public DialogueData Description { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        public void Start()
        {
            InventoryManager.Instance.ItemDictionary[Name] = this;
        }
    }        
}
