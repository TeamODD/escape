using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private bool _status; // �ϴ� true = dream  |  false = real
    public GameObject dreamItem;  // �ް�ü �� 
    public GameObject realItem; // ���� ��ü �� 


    public void SwitchItemStatus() //������ ���� �ٲٱ� 
    {
        _status = !_status;
    }

    public Sprite GetItemIcon() // ���� ������ ������ ��ȯ 
    {
        if(_status)
        {
            return dreamItem.GetComponent<Image>().sprite;
        }
        else
        {
            return realItem.GetComponent<Image>().sprite;
        }
    }
}
