using Assets.Scripts.Dialogue;
using UnityEngine;

public class DreamBolttleScript : ClickHandler
{
    public AudioClip drinkSFX;
    public ZoomImage ZoomImage;
    public ZoomTarget secondZoomTarget;
    public bool isDrink=false;
    public RealityBottleScript realityBottleScript;
    private bool _isRequestItem;
    
    public override void DoToWork()
    {

        if (flowIdx == 0)
        {
            _zoomTarget.ZoomRequset();
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            DialogueController.Instance.applyButtonOn(4);
        }
        else if (flowIdx ==1 )
        {
            
            DialogueController.Instance.PlayDialogue(dialogueData[1]);
            
        }
       
      
    }

    public void DrinkDreamBottle()
    {
        SoundControllerScript.Instance.StartEffectBgm(drinkSFX);
        
        //SwitchisEnableZoom(false);
        OneFlowPlus();
        realityBottleScript.OneFlowPlus();
        secondZoomTarget.ZoomRequset();
        _isRequestItem = true;
    }

    public void GetItem()
    {
        if (_isRequestItem)
        {
            ZoomImage.OnHide();
            flowController.CheckGameObject(gameObject);
            _isRequestItem = false;
        }
    }
}
