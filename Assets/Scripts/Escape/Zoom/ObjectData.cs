namespace Assets.Scripts.Escape.Zoom
{
    using UnityEngine;
    using UnityEngine.Events;
    using Sirenix.OdinInspector;
    using Inventory;

    public class ObjectData : SerializedMonoBehaviour
    {
        [field: SerializeField] public UnityEvent OnItemUsed { get; private set; }
        [field: SerializeField] public ItemData ItemData { get; private set; }
        private void Start()
        {
            OnItemUsed.AddListener(() => InventoryManager.Instance.SetItemSlots());
        }
    }        
}
