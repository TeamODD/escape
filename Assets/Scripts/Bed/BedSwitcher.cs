using System;
using UnityEngine;

public class BedSwitcher : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance?.SwitchWorld();
    }
}
