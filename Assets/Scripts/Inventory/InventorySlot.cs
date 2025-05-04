using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Item item;  // 슬롯에 들어갈 아이템 
    public GameObject icon; // 아이콘



    public void UpdateSlot()
    {
        if (item != null) // 만약 현재 아이템이 들어와있다면 
        {
            icon.GetComponent<Image>().sprite = item.icon; // 아이템의  아이콘으로 가져와서 
            icon.SetActive(true);//아이콘 활성화
        }
        else
        {
            icon.SetActive(false); // 없으면 그대로 비활성화 
        }
    }



 
}
