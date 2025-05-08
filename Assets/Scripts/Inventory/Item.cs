using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Item
{
    private bool _status; // 일단 true = dream  |  false = real
    private GameObject _dreamItem;  // 꿈객체 들어감 
    private GameObject _realItem; // 현실 객체 들어감 

    public void CreateItem(bool status, GameObject dream, GameObject real)
    {
        _status = status;
        _dreamItem = dream;
        _realItem = real;
    }

    public void SwitchItemStatus(bool status) //아이템 상태 바꾸기 
    {
        _status = status;
    }

    public Sprite GetItemIcon() // 현재 상태의 아이콘 반환 
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