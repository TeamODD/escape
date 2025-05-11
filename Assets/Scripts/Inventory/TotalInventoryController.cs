using NUnit.Framework.Internal.Commands;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TotalInventoryController : MonoBehaviour
{
    private bool _isInventoryFirst;
    
    public ItemMappingTable mappingTable;
    public GameObject itemForTest;
    public List<Inventory> inventorys=new List<Inventory>();
    public List<GameObject> canInsertObjects = new List<GameObject>();
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initSetting();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 숫자 키보드 '1' 키 (키패드 아님)
        {
            Debug.Log("input 1 key");
            MakeItemForTest();
        }
    }


    private void _initSetting() //최초 세팅 인벤토리 전부 비활성화 후 첫번째 인벤토리만 보이도록 설정 
    {
        for (int i = 0; i < inventorys.Count; i++)
        {
            
            inventorys[i].gameObject.SetActive(false);
        }

        _isInventoryFirst = false;
        SwitchUsingInventory();
    }
    public void SwitchUsingInventory() //사용중인 인벤토리 바꾸기 0->1 , 1->0
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
    
    public void AllInventorySwitchStatus(bool status) //모든 인벤토리의 상태(꿈과 현실)를 한번에 변환 
    {
        for (int i = 0; i < inventorys.Count; i++)
        {
            
            inventorys[i].SwitchInventoryStatus(status);
            
        }
    }
    
    
    public void CheckCanInsertObject(GameObject input)
    {
        int idx = canInsertObjects.IndexOf(input);
        if (idx!=-1) // 만약 삽입 가능한 리스트에 들어가있는 오브젝트라면 
        {
            Item inputItem = new Item();
            GameObject Partner = mappingTable.GetPartner(input); //매핑되는 오브젝트 얻어옴
            
            if (mappingTable.CheckIsDreamObject(input)) //넣은게 꿈 아이템일때 = 꿈 일때 
            {

                inputItem.CreateItem(true, input,mappingTable.GetHighLightItem(input) ,Partner,mappingTable.GetHighLightItem(Partner));
            }
            else
            {
                inputItem.CreateItem(true, Partner, mappingTable.GetHighLightItem(Partner),input,mappingTable.GetHighLightItem(input));
            }
            
            if (idx <= 4) //0번인벤토리에 삽입
            {
                inventorys[0].AddItem(inputItem,idx);
            }
            else // 1번 입벤토리에 삽임
            {
                inventorys[1].AddItem(inputItem,idx-5);
            }
            
        }
        else
        {
            return;
        }
    }

    public void MakeItemForTest()
    {
        if(itemForTest!=null)
        {
            CheckCanInsertObject(itemForTest);
        }
        
       
    }
}
