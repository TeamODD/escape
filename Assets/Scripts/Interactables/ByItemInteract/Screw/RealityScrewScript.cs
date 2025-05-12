using UnityEngine;

public class RealityScrewScript : ClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void DoToWork()
    {
        if (flowIdx == 1)
        {
            flowController.CheckGameObject(gameObject); 
            OneFlowPlus();
        }
    }
}
