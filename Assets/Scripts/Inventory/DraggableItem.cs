using UnityEngine;
using UnityEngine.EventSystems;
public class DraggableItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging drag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
    }
}
