using Assets.Scripts.Dialogue;
using UnityEngine;

public class DreamTeddyBearScript : ClickHandler
{
    public ZoomImage zoomImage;
    public ClickHandler trashWarm;
    public AudioClip KnifeSFX;
    public ZoomTarget secondZoomTarget;
    private bool _requestItem;
    public override void DoToWork()
    {
        if (flowIdx == 0)
        {
            //푹신해 보이는
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            DialogueController.Instance.applyDialogueOn();
            
            _zoomTarget.ZoomRequset();
            _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
            _zoomTarget.SwitchHitImageName("DreamBearImage");
        }
        if (flowIdx == 1)
        {
            
            
        }
    }

    public void GetKnife()
    {
        _requestItem = true;
        DialogueController.Instance.PlayDialogue(dialogueData[1]);
        //편지칼로 인형
        secondZoomTarget.ZoomRequset();
        _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
        
       
        _soundController.StartEffectBgm(KnifeSFX);
        OneFlowPlus();
        trashWarm.OneFlowPlus();
       
    }

    public void GetItem()
    {
        if (_requestItem )
        {
            flowController.CheckGameObject(gameObject);
            zoomImage.OnHide();
            _requestItem = false;
        }
        
    }
}
