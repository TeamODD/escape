using UnityEngine;

public class RealityDrawerScript : ClickHandler
{
    public GameObject secondDrawer;
    public override void DoToWork()
    {
        if (flowIdx == 0)
        {
            secondDrawer.transform.localPosition = new Vector3(0.289f, -0.182f, 0f);

            flowIdx++;
        }
     
    }
}
