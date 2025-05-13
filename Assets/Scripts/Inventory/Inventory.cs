using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public List<InventorySlot> inventorySlots=new List<InventorySlot>(); // �����ϴ� �κ��丮�� �� ����Ʈ
    
    
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
    
    public void AddItem(Item item,int index) //���ο� ������ �κ��丮�� �ֱ�
    {
        
      
        
       
        _itemList[index] = item; //���� �������� ������ ����Ʈ�� �ְ� 
        inventorySlots[index].GetNewItem(item); //�κ��丮 ������ �����ۿ��� �ִ´� 
                

    }


    public void SwitchInventoryStatus(bool status) // �ް� ������ �ٲ� �ܰ� ����ġ�� ���� �Լ� 
    {
        
        for (int i = 0; i < _itemList.Length; i++) // �κ��丮 �ȿ� ����ִ� �����۵��� ���� ������ ����
        {
            
            //_itemList[i].SwitchItemStatus();
            inventorySlots[i].SwitchItem(status);
            
        }
       
        UpdateAllSlotUI(); // ���ο� �������� �������� Slot ������Ʈ 
    }


    public bool CheckAllItemGet()
    {
        bool temp=true;
        for (int i = 0; i < _itemList.Length; i++) // �κ��丮 �ȿ� ����ִ� �����۵��� ���� ������ ����
        {
            
            //_itemList[i].SwitchItemStatus();
            if (_itemList[i] == null)//�����ۿ� ��ĭ�� �ϳ��� �ִٸ�
            {
                temp = false;
                break;
            }
            
        }

        return temp;
    }


}