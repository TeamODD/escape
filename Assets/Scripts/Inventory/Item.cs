using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Item
{
    private bool _status; // �ϴ� true = dream  |  false = real
    private GameObject _dreamItem;  // �ް�ü �� 
    private GameObject _dreamHighlight;
    private GameObject _realItem; // ���� ��ü �� 
    private GameObject _realHighlight;
    
    public void CreateItem(bool status, GameObject dream,GameObject dreamHighlight,GameObject real,GameObject realHighlight)
    {
        _status = status;
        _dreamItem = dream;
        _dreamHighlight = dreamHighlight;
        _realItem = real;
        _realHighlight = realHighlight;
    }

    public void SwitchItemStatus(bool status) //������ ���� �ٲٱ� 
    {
        _status = status;
    }

    public Sprite GetItemIcon() // ���� ������ ������ ��ȯ 
    {
        if(_status)
        {
            
            return _dreamItem.GetComponent<Image>().sprite;
            
        }
        else
        {
            return _realItem.GetComponent<Image>().sprite;
        }
    }

    public Sprite GetHighLightIcon() // ���� ������ ������ ��ȯ 
    {
        if(_status)
        {
            
            return _dreamHighlight.GetComponent<Image>().sprite;
            
        }
        else
        {
            return _realHighlight.GetComponent<Image>().sprite;
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