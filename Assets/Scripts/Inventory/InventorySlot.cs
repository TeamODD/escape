using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    private Item _item;  // ���� ������ ������
    private GameObject _icon; // ������


    public void GetNewItem(Item input) //������ ������ ���ο� ������ �ֱ� 
    {
        _item = input;
    }


    public void UpdateSlot() // ���� ���� ���� ������Ʈ 
    {
        if (_item != null) // ���� ���� �������� �����ִٸ� 
        {

            _icon.GetComponent<Image>().sprite = _item.GetItemIcon(); // ���� ��������  �������� �����ͼ� ������ �� ���� 
            _icon.SetActive(true);//������ Ȱ��ȭ
        }
        else
        {
            _icon.SetActive(false); // ������ �״�� ��Ȱ��ȭ 
        }
    }



 
}
