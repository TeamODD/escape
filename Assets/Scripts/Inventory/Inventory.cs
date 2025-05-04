using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<InventorySlot> inventorySlots=new List<InventorySlot>(); // �����ϴ� �κ��丮�� �� ����Ʈ

    public Item[] itemList; // ���� �κ��丮�� �����ϴ� ������ ���� 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemList = new Item[inventorySlots.Count]; //���� �κ��丮���� ������ŭ �κ��丮 ����Ʈ ũ�� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private bool CheckCanAdd(Item item) // ������ ������ ������ ��ĭ�� �ִ��� üũ 
    {

        for (int i = 0; i < itemList.Length; i++) // �κ��丮 ��ĭ ã��
        {
            if (itemList[i] == null) //��ĭ ã���� ����
            {
                itemList[i] = item; //���� �������� ������ ����Ʈ�� �ְ� 
                inventorySlots[i].item = item; //�κ��丮 ������ �����ۿ��� �ִ´� 
                return true;
            }

        }
        return false;
    }

    public void UpdateSlotUI()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].UpdateSlot(); // ���� �����ϴ� ��罽�Ե鿡�� UpdateSlotȣ��
        }
    }


    public void AddItem(Item item) //���ο� ������ �κ��丮�� �ֱ�
    {
        if(CheckCanAdd(item)) // ��ĭ �� �ִٸ� ������ �ִ� 
        {
            UpdateSlotUI();
        }

    }
}
