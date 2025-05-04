using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Item item;  // ���Կ� �� ������ 
    public GameObject icon; // ������



    public void UpdateSlot()
    {
        if (item != null) // ���� ���� �������� �����ִٸ� 
        {
            icon.GetComponent<Image>().sprite = item.icon; // ��������  ���������� �����ͼ� 
            icon.SetActive(true);//������ Ȱ��ȭ
        }
        else
        {
            icon.SetActive(false); // ������ �״�� ��Ȱ��ȭ 
        }
    }



 
}
