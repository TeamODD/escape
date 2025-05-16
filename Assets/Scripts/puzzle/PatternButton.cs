using UnityEditor;
using UnityEngine;

public class PatternButton : MonoBehaviour
{
    public Testing testingScript;

   

    public void SwitchPattern()
    {
        testingScript.NextPattern();
    }
}
