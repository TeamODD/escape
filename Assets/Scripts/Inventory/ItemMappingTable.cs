using UnityEngine;
using System.Collections.Generic;
public class ItemMappingTable : MonoBehaviour
{
    public List<ItemPair> mappingTable;

    public List<HighLightPair> HighLightTable;
    
    public List<InventoryMappingPair> InventoryMappingTable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [System.Serializable]
    public class ItemPair //현재 씬에서의 매칭 정보
    {
        public GameObject dreamItem;
        public GameObject realItem;
    }

   

    public bool IsExist(GameObject input) // 현재 input이 후보리스트에 있는건지 확인 
    {
        return mappingTable.Exists(pair => pair.dreamItem == input || pair.realItem == input);
    }
    

    public bool CheckIsBroochType(GameObject input) // 현재 input이 브로치인지 = 인벤토리 2에 들어가야하는지
    {
        /*
        if (input == 브로치)
        {
            return true;
        }
        */
        return false;
    }
    public bool CheckIsDreamObject(GameObject input)
    {
        foreach (var pair in mappingTable)
        {
            if (pair.dreamItem == input)
            {
                return true;
            }
        }

        return false;
    }
    public GameObject GetPartner(GameObject input) // 자신의 파트너 정보 가져오기 
    {
        foreach (var pair in mappingTable)
        {
            if (pair.dreamItem == input)
            {
                return pair.realItem;
            }
            else if (pair.realItem == input)
            {
                return pair.dreamItem;
            }
        }
        return null;
    }



    [System.Serializable]
    public class HighLightPair //하이라이트 정보매칭 
    {
        public GameObject targetItem;
        public GameObject highlightingItem;
    }
    
    public GameObject GetHighLightItem(GameObject input) // 자신의 파트너 정보 가져오기 
    {
        Debug.Log(input);
        foreach (var pair in HighLightTable)
        {
            if (pair.targetItem.name == input.name)
            {
                return pair.highlightingItem;
            }
        }

        Debug.Log("Highlight 대상 없음");
        return null;
    }
    
    
    [System.Serializable]
    public class InventoryMappingPair //현재 삽입되는 아이템이 인벤토리에서 나올 정보를 담은 테이블  참고로 삽입때 사용되는 아이템만 저장됌 
    {
        public GameObject insertedItem;
        public GameObject dreamIconObject;
        public GameObject realIconObject;
    }

  
    public GameObject GetInvenDreamIcon(GameObject input)
    {
        foreach (var pair in InventoryMappingTable)
        {
            if (pair.insertedItem == input)
            {
                return pair.dreamIconObject;
            }
        }
        Debug.Log("XX");
        return null;
    }
    public GameObject GetInvenRealIcon(GameObject input)
    {
        foreach (var pair in InventoryMappingTable)
        {
            if (pair.insertedItem == input)
            {
                return pair.realIconObject;
            }
        }
        Debug.Log("X");
        return null;
    }
    

}