namespace Assets.Scripts.Escape.Inventory
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class InventoryPage : SerializedMonoBehaviour
    {
        [field: SerializeField] public ItemData[] RealityItemDataArray { get; private set; } = new ItemData[5];
        [field: SerializeField] public ItemData[] DreamItemDataArray { get; private set; } = new ItemData[5];
    }
}
