using UnityEngine;

public class RealityDrawerScript : ClickHandler
{
    public GameObject secondDrawer;
    public override void DoToWork()
    {
        if (flowIdx == 0)
        {
            flowIdx++;
        }
     
    }
}
