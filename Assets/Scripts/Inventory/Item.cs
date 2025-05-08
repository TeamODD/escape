using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Item
{
    private bool _status; // �ϴ� true = dream  |  false = real
    private GameObject _dreamItem;  // �ް�ü �� 
    private GameObject _realItem; // ���� ��ü �� 

    public void CreateItem(bool status, GameObject dream, GameObject real)
    {
        _status = status;
        _dreamItem = dream;
        _realItem = real;
    }

    public void SwitchItemStatus(bool status) //������ ���� �ٲٱ� 
    {
        _status = status;
    }

    public Sprite GetItemIcon() // ���� ������ ������ ��ȯ 
    {
        if(_status)
        {
            Debug.Log("getdreamsprite");
            return _dreamItem.GetComponent<Image>().sprite;
            
        }
        else
        {
            return _realItem.GetComponent<Image>().sprite;
        }
    }

    public GameObject ExtractItem()
    {
        if (_status)
        {
            return _dreamItem;
        }
        else
        {

            return _realItem;
        }
    }


}