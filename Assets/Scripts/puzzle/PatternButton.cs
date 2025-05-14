using UnityEngine;

public class PatternButton : MonoBehaviour
{
    public Testing testingScript;

    private void OnMouseDown()
    {
        testingScript.NextPattern();
    }
}
