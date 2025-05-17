using Assets.Scripts.Dialogue;
using UnityEngine;

public class DreamCrowScropt : ClickHandler
{
    public ZoomImage ZoomImage;
    public AudioClip eatSFX;
    public ClickHandler dreamBackground;
    public GameObject realityFlowerPot;
    public RealityScrewScript realityScrewScript;
    public RealityStainGlass realityStainGlass;
    public RealityPotScript realityPotScript;
    public DreamPotScript dreamPotScript;
    public LighControlScript lighControlScript;

    public ZoomTarget secondZoomTarget;

    private bool _isCrowGone;
    //스크류오브젝트 생성후적용해야함
    public override void DoToWork()
    {
        if (flowIdx == 0)
        {
            //까마귀..?
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            DialogueController.Instance.applyDialogueOn();
            _zoomTarget.ZoomRequset();
            _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
            _zoomTarget.SwitchHitImageName("DreamCrowImage");
        }
        else if (flowIdx == 1)
        {
            //아무것도
            DialogueController.Instance.PlayDialogue(dialogueData[1]);
        }
    }

    public void GetWarm()
    {
        //애벌레 모양
        DialogueController.Instance.PlayDialogue(dialogueData[2]);
        secondZoomTarget.ZoomRequset();
        _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
        _isCrowGone = true;
        SoundControllerScript.Instance.StartEffectBgm(eatSFX);
       
        OneFlowPlus();
        dreamPotScript.OneFlowPlus();
        realityStainGlass.OneFlowPlus();
        realityPotScript.OneFlowPlus();
        realityScrewScript.OneFlowPlus();
        dreamBackground.OneFlowPlus();
     
        realityFlowerPot.SetActive(true);
        
        realityFlowerPot.GetComponent<RealityFlowerPotScript>().OneFlowPlus();
        realityFlowerPot.GetComponent<SpriteRenderer>().sortingOrder=3;
    }

    public void CrowIsGone()
    {
        if (_isCrowGone)
        {
            GameManager.Instance.isLightOn = true;
            
            _isCrowGone = false;
            ZoomImage.OnHide();
        }
        
    }
}
