using UnityEngine;
using System.Collections.Generic;
public class ItemMappingTable : MonoBehaviour
{
    public List<ItemPair> mappingTable;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [System.Serializable]
    public class ItemPair
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
    
}