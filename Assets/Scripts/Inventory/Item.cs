using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Item
{
    private bool _status; // 일단 true = dream  |  false = real
    private GameObject _dreamItem;  // 꿈객체 들어감 
    private GameObject _dreamHighlight;
    private GameObject _realItem; // 현실 객체 들어감 
    private GameObject _realHighlight;
    
    public void CreateItem(bool status, GameObject dream,GameObject dreamHighlight,GameObject real,GameObject realHighlight)
    {
        _status = status;
        _dreamItem = dream;
        _dreamHighlight = dreamHighlight;
        _realItem = real;
        _realHighlight = realHighlight;
    }

    public void SwitchItemStatus(bool status) //아이템 상태 바꾸기 
    {
        _status = status;
    }

    public Sprite GetItemIcon() // 현재 상태의 아이콘 반환 
    {
        if(_status)
        {
            
            return _dreamItem.GetComponent<SpriteRenderer>().sprite;
            
        }
        else
        {
            return _realItem.GetComponent<SpriteRenderer>().sprite;
        }
    }

    public Sprite GetHighLightIcon() // 현재하이라이트 아이콘 반환 
    {
        if(_status)
        {
            
            return _dreamHighlight.GetComponent<SpriteRenderer>().sprite;
            
        }
        else
        {
            return _realHighlight.GetComponent<SpriteRenderer>().sprite;
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

    public GameObject GetDreamGameObject()
    {

        return _dreamItem;
    }

    public bool GetItemStatus()
    {
        return _status;
    }
}