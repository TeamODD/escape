using Assets.Scripts.Dialogue;
using UnityEngine;

public class DreamTeddyBearScript : ClickHandler
{
    public ZoomImage zoomImage;
    public ClickHandler trashWarm;
    public AudioClip KnifeSFX;
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
            flowController.CheckGameObject(gameObject);
            
        }
    }

    public void GetKnife()
    {
        //편지칼로 인형
        DialogueController.Instance.PlayDialogue(dialogueData[1]);
        zoomImage.OnHide();
        _soundController.StartEffectBgm(KnifeSFX);
        OneFlowPlus();
        trashWarm.OneFlowPlus();
    }
  
}
