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


    public void AddItem(Item item) //���ο� ������ �κ��丮�� �ֱ�
    {
        for (int i = 0; i < _itemList.Length; i++) // �κ��丮 ��ĭ ã�� 
        {
            if (_itemList[i] == null) //��ĭ ã���� ����
            {
                _itemList[i] = item; //���� �������� ������ ����Ʈ�� �ְ� 
                inventorySlots[i].GetNewItem(item); //�κ��丮 ������ �����ۿ��� �ִ´� 
            }
        }
            UpdateAllSlotUI(); // ���ο� �������� �������� Slot ������Ʈ 

    }


    public void SwitchInventoryStatus() // �ް� ������ �ٲ� �ܰ� ����ġ�� ���� �Լ� 
    {
        for (int i = 0; i < _itemList.Length; i++) // �κ��丮 �ȿ� ����ִ� �����۵��� ���� ������ ����
        {
            _itemList[i].SwitchItemStatus();
        }
        UpdateAllSlotUI(); // ���ο� �������� �������� Slot ������Ʈ 
    }



}
