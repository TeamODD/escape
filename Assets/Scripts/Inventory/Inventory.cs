using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<InventorySlot> inventorySlots=new List<InventorySlot>(); // 존재하는 인벤토리가 들어갈 리스트

    public Item[] itemList; // 현재 인벤토리에 존재하는 아이템 종류 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemList = new Item[inventorySlots.Count]; //현재 인벤토리슬롯 개수만큼 인벤토리 리스트 크기 초기화
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private bool CheckCanAdd(Item item) // 아이템 삽입이 가능한 빈칸이 있는지 체크 
    {

        for (int i = 0; i < itemList.Length; i++) // 인벤토리 빈칸 찾기
        {
            if (itemList[i] == null) //빈칸 찾으면 삽입
            {
                itemList[i] = item; //현재 아이템을 아이템 리스트에 넣고 
                inventorySlots[i].item = item; //인벤토리 슬롯의 아이템에도 넣는다 
                return true;
            }

        }
        return false;
    }

    public void UpdateSlotUI()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].UpdateSlot(); // 현재 잔존하는 모든슬롯들에게 UpdateSlot호출
        }
    }


    public void AddItem(Item item) //새로운 아이템 인벤토리에 넣기
    {
        if(CheckCanAdd(item)) // 빈칸 이 있다면 넣을수 있다 
        {
            UpdateSlotUI();
        }

    }
}
