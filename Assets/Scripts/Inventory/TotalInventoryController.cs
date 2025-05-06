using System.Collections.Generic;
using UnityEngine;

public class TotalInventoryController : MonoBehaviour
{
    private bool _isInventoryFirst;
    public List<Inventory> inventorys=new List<Inventory>(); 
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void _initSetting()
    {
        for (int i = 0; i < inventorys.Count; i++)
        {
            
            inventorys[i].gameObject.SetActive(false);
        }

        _isInventoryFirst = false;
        SwitchUsingInventory();
    }
    public void SwitchUsingInventory()
    {
        _isInventoryFirst = !_isInventoryFirst;

        if (_isInventoryFirst)
        {
            inventorys[0].gameObject.SetActive(true);
            inventorys[1].gameObject.SetActive(false);
        }
        else
        {
            inventorys[0].gameObject.SetActive(false);
            inventorys[1].gameObject.SetActive(true);
        }
    }
    
    public void AllInventorySwitchStatus() //모든 인벤토리의 상태를 한번에 변환 
    {
        for (int i = 0; i < inventorys.Count; i++)
        {
            inventorys[i].SwitchInventoryStatus();
        }
    }
    
}
