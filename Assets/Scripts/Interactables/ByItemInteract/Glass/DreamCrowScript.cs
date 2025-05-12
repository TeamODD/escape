using UnityEngine;

public class DreamCrowScropt : ClickHandler
{
    public GameObject realityFlowerPot;
    public RealityScrewScript realityScrewScript;
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
        realityScrewScript.OneFlowPlus();
        
        realityFlowerPot.SetActive(true);
        Debug.Log("active");
        realityFlowerPot.GetComponent<RealityFlowerPotScript>().OneFlowPlus();
        realityFlowerPot.GetComponent<SpriteRenderer>().sortingOrder=3;
    }
}
