using UnityEngine;

public class DreamCrowScropt : ClickHandler
{
    public ZoomImage ZoomImage;
    public AudioClip eatSFX;
    public GameManager gameManager;
    public GameObject realityFlowerPot;
    public RealityScrewScript realityScrewScript;
    public RealityStainGlass realityStainGlass;
    public RealityPotScript realityPotScript;
    public LighControlScript lighControlScript;
    //스크류오브젝트 생성후적용해야함
    public override void DoToWork()
    {
        if (flowIdx == 0)
        {
            _zoomTarget.ZoomRequset();
            _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
            _zoomTarget.SwitchHitImageName("DreamCrowImage");
        }

    }

    public void GetWarm()
    {
        ZoomImage.OnHide();
        _soundController.StartEffectBgm(eatSFX);
        OneFlowPlus();
        realityStainGlass.OneFlowPlus();
        realityPotScript.OneFlowPlus();
        realityScrewScript.OneFlowPlus();
        gameManager.isLightOn = true;
        realityFlowerPot.SetActive(true);
        Debug.Log("active");
        realityFlowerPot.GetComponent<RealityFlowerPotScript>().OneFlowPlus();
        realityFlowerPot.GetComponent<SpriteRenderer>().sortingOrder=3;
    }
}
