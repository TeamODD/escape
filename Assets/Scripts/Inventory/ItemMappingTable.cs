using UnityEngine;
using System.Collections.Generic;
public class ItemMappingTable : MonoBehaviour
{
    public List<ItemPair> itemmaps;
    
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
    
}
