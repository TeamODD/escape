using System;
using UnityEngine;

public class BedSwitcher : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("trySwitch");
        GameManager.Instance?.SwitchWorld();
        
    }
    
    
    
}
