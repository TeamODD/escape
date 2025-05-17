namespace Assets.Scripts.Escape.Inventory
{
    using Assets.Scripts.Escape.Zoom;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class ItemObject : SerializedMonoBehaviour
    {
        public ItemData ItemData;

        public void UseItemOnTargetObject(PointerEventData eventData)
        {
            if (ItemData == null)
            {
                return;
            }

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);

            RaycastHit2D[] hit = Physics2D.RaycastAll(worldPoint, Vector2.zero);
            foreach (RaycastHit2D hit2d in hit)
            {
                if (hit2d.collider.CompareTag("Target"))
                {
                    ZoomManager zoomManager = hit2d.collider.GetComponentInParent<ZoomManager>();
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
