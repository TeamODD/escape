using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<InventorySlot> inventorySlots=new List<InventorySlot>(); // 존재하는 인벤토리가 들어갈 리스트

    private Item[] _itemList; // 현재 인벤토리에 존재하는 아이템 종류 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _itemList = new Item[inventorySlots.Count]; //현재 인벤토리슬롯 개수만큼의 크기인 인벤토리 리스트 만들기
    }


    public void UpdateAllSlotUI()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].UpdateSlot(); // 현재 잔존하는 모든슬롯들에게 UpdateSlot호출
        }
    }


    public void AddItem(Item item) //새로운 아이템 인벤토리에 넣기
    {
        for (int i = 0; i < _itemList.Length; i++) // 인벤토리 빈칸 찾기 
        {
            if (_itemList[i] == null) //빈칸 찾으면 삽입
            {
                _itemList[i] = item; //현재 아이템을 아이템 리스트에 넣고 
                inventorySlots[i].GetNewItem(item); //인벤토리 슬롯의 아이템에도 넣는다 
            }
        }
            UpdateAllSlotUI(); // 새로운 아이템이 들어왔으니 Slot 업데이트 

    }


    public void SwitchInventoryStatus() // 꿈과 현실이 바뀔때 외관 스위치를 위한 함수 
    {
        for (int i = 0; i < _itemList.Length; i++) // 인벤토리 안에 들어있는 아이템들의 상태 일제히 변경
        {
            _itemList[i].SwitchItemStatus();
        }
        UpdateAllSlotUI(); // 새로운 아이템이 들어왔으니 Slot 업데이트 
    }



}
