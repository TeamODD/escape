using NUnit.Framework.Internal.Commands;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class TotalInventoryController : MonoBehaviour
{
    

    public AudioClip itemPickSFX;
    public ItemMappingTable mappingTable;
    public GameObject itemForTest;
    public List<Inventory> inventorys=new List<Inventory>();
    public List<GameObject> canInsertObjects = new List<GameObject>();
    private SoundControllerScript _soundControllerScript;
    private bool _isInventoryFirst;

    private InvenAlarmScript _invenAlarm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initSetting();
        _soundControllerScript = SoundControllerScript.Instance;
        _invenAlarm = GetComponent<InvenAlarmScript>();
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
            
            SetRenderVisible(inventorys[i].gameObject, false);
        }

        _isInventoryFirst = false;
        SwitchUsingInventory();
    }
    public void SwitchUsingInventory() //사용중인 인벤토리 바꾸기 0->1 , 1->0
    {
        _isInventoryFirst = !_isInventoryFirst;

        if (_isInventoryFirst)
        {
            SetRenderVisible(inventorys[0].gameObject, true);
            SetRenderVisible(inventorys[1].gameObject, false);
            
        }
        else
        {
            SetRenderVisible(inventorys[0].gameObject, false);
            SetRenderVisible(inventorys[1].gameObject, true);
        }
    }
    
    public void AllInventorySwitchStatus(bool status) //모든 인벤토리의 상태(꿈과 현실)를 한번에 변환 
    {
        for (int i = 0; i <= 1; i++)
        {
            
            inventorys[i].SwitchInventoryStatus(status);
            
        }
    }
    
    
    public void CheckCanInsertObject(GameObject input) //현재 클릭된 물체 
    {
        int idx = canInsertObjects.IndexOf(input); // 삽입되는 정보가 담긴 리스에 담긴 오브젝트라면 
        if (idx!=-1) // 만약 삽입 가능한 리스트에 들어가있는 오브젝트라면 
        {
            
            _soundControllerScript.StartEffectBgm(itemPickSFX);
            Item inputItem = new Item();
            GameObject dreamObject = mappingTable.GetInvenDreamIcon(input);
            GameObject realObject = mappingTable.GetInvenRealIcon(input);

            
            if (mappingTable.CheckIsDreamObject(input)) //넣은게 꿈 아이템일때 = 꿈 일때  전체 매핑 테이블에서 비교 
            {

                inputItem.CreateItem(true,dreamObject ,mappingTable.GetHighLightItem(dreamObject) ,realObject,mappingTable.GetHighLightItem(realObject));
            }
            else
            {
                inputItem.CreateItem(false, dreamObject, mappingTable.GetHighLightItem(dreamObject),realObject,mappingTable.GetHighLightItem(realObject));
            }
            
            if (idx <= 4) //0번인벤토리에 삽입
            {
                inventorys[0].AddItem(inputItem,idx);
                
            }
            else // 1번 입벤토리에 삽임
            {
                inventorys[1].AddItem(inputItem,idx-5);
            }
            _invenAlarm.AlarmGetNewItem(dreamObject);
            
        }
        else
        {
            return;
        }
    }


    public bool CheckAllBrouchGet()
    {
        
        return inventorys[1].CheckAllItemGet();
    }
    public void MakeItemForTest()
    {
        if(itemForTest!=null)
        {
            CheckCanInsertObject(itemForTest);
        }
        
       
    }
    public void SetRenderVisible(GameObject panel, bool visible)
    {
        CanvasGroup cg = panel.GetComponent<CanvasGroup>();
        if (cg == null)
        {
            cg = panel.AddComponent<CanvasGroup>();
        }

        cg.alpha = visible ? 1f : 0f;
        cg.interactable = visible;
        cg.blocksRaycasts = visible;
    }
}
