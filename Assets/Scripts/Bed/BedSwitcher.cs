using System;
using UnityEngine;

public class BedSwitcher : MonoBehaviour
{
    
  
    public void GetMouseDown()
    {
        GameManager.Instance?.SwitchWorld();
    }
        
    
    
    
    
}
