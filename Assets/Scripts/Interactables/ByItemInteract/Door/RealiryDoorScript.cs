using Assets.Scripts.Dialogue;
using UnityEngine;

public class RealiryDoorScript : ClickHandler
{
    public override void DoToWork()
    {
        //문은굳게 닫혀있다
        
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            DialogueController.Instance.applyDialogueOn();
            _zoomTarget.ZoomRequset();
            _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
            _zoomTarget.SwitchHitImageName("ReailtyDoor");

        
    }


    
}
