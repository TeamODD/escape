using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    private Item _item;  // 현재 슬롯의 아이템
    private GameObject _icon; // 아이콘


    public void GetNewItem(Item input) //아이템 변수에 새로운 아이템 넣기 
    {
        _item = input;
    }


    public void UpdateSlot() // 현재 슬롯 상태 업데이트 
    {
        if (_item != null) // 만약 현재 아이템이 들어와있다면 
        {

            _icon.GetComponent<Image>().sprite = _item.GetItemIcon(); // 현재 아이템의  아이콘을 가져와서 아이콘 에 저장 
            _icon.SetActive(true);//아이콘 활성화
        }
        else
        {
            _icon.SetActive(false); // 없으면 그대로 비활성화 
        }
    }



 
}
