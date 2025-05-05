using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private bool _status; // 일단 true = dream  |  false = real
    public GameObject dreamItem;  // 꿈객체 들어감 
    public GameObject realItem; // 현실 객체 들어감 


    public void SwitchItemStatus() //아이템 상태 바꾸기 
    {
        _status = !_status;
    }

    public Sprite GetItemIcon() // 현재 상태의 아이콘 반환 
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
