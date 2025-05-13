using UnityEngine;

public class RealityFountainPen : ClickHandler
{
    public override void DoToWork()
    {
        if (flowIdx == 0)
        {
            OneFlowPlus();
            flowController.CheckGameObject(gameObject);
            
        }
    }
}
