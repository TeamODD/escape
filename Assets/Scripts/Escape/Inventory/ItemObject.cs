namespace Assets.Scripts.Escape.Inventory
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using Sirenix.OdinInspector;
    using Zoom;

    public class ItemObject : SerializedMonoBehaviour
    {
        public ItemData ItemData;
        [SerializeField] private GraphicRaycaster raycaster;

        public void UseItemOnTargetObject(PointerEventData eventData)
        {
            if (ItemData == null)
            {
                return;
            }
            
            List<RaycastResult> results = new();
            raycaster.Raycast(eventData, results);

            foreach (var result in results)
            {
                if (result.gameObject.CompareTag("Target"))
                {
                    ZoomManager zoomManager = result.gameObject.GetComponentInParent<ZoomManager>();
                    if (zoomManager.ObjectData != null && zoomManager.ObjectData.ItemData.Name == ItemData.Name)
                    {
                        zoomManager.ObjectData.OnItemUsed.Invoke();
                    }
                    break;
                }
            }
        }
    }
}
