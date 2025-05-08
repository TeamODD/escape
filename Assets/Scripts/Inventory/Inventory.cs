using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public List<InventorySlot> inventorySlots=new List<InventorySlot>(); // �����ϴ� �κ��丮�� �� ����Ʈ


    public List<GameObject> inventoryInputOrder = new List<GameObject>();
    
    private Item[] _itemList; // ���� �κ��丮�� �����ϴ� ������ ���� 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _itemList = new Item[inventorySlots.Count]; //���� �κ��丮���� ������ŭ�� ũ���� �κ��丮 ����Ʈ �����
    }


    public void UpdateAllSlotUI()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].UpdateSlot(); // ���� �����ϴ� ��罽�Ե鿡�� UpdateSlotȣ��
        }
    }

    public int GetInputIndex(GameObject input)
    {
        return inventoryInputOrder.IndexOf(input);
    }
 
    public void AddItem(Item item) //���ο� ������ �κ��丮�� �ֱ�
    {
        int index = GetInputIndex(item.ExtractItem());
      
        
        Debug.Log("calladditem");   
        _itemList[index] = item; //���� �������� ������ ����Ʈ�� �ְ� 
        inventorySlots[index].GetNewItem(item); //�κ��丮 ������ �����ۿ��� �ִ´� 
                

    }


    public void SwitchInventoryStatus(bool status) // �ް� ������ �ٲ� �ܰ� ����ġ�� ���� �Լ� 
    {
        Debug.Log("SwitchStatus");
        for (int i = 0; i < _itemList.Length; i++) // �κ��丮 �ȿ� ����ִ� �����۵��� ���� ������ ����
        {
            
            //_itemList[i].SwitchItemStatus();
            inventorySlots[i].SwitchItem(status);
            
        }
       
        UpdateAllSlotUI(); // ���ο� �������� �������� Slot ������Ʈ 
    }



}