using UnityEngine;

public class DreamCrowScropt : ClickHandler
{
    public RealityStainGlass realityStainGlass;
    public RealityPotScript realityPotScript;
    //스크류오브젝트 생성후적용해야함
    public override void DoToWork()
    {


    }

    public void GetWarm()
    {
        OneFlowPlus();
        realityStainGlass.OneFlowPlus();
        realityPotScript.OneFlowPlus();
    }
}
