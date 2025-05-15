using Assets.Scripts.Dialogue;
using UnityEngine;

public class RealiryDoorScript : ClickHandler
{
    public override void DoToWork()
    {
        //문은굳게 닫혀있다
        
            


            if (flowIdx == 0)
            {
                DialogueController.Instance.PlayDialogue(dialogueData[0]);
                DialogueController.Instance.applyDialogueOn();
                _zoomTarget.ZoomRequset();
                _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
                _zoomTarget.SwitchHitImageName("ReailtyDoor");
            }
            else if (flowIdx==1)
            {
                //현실로 나가는 엔딩 출력부분
                DialogueController.Instance.PlayDialogue(dialogueData[1]);
                EndingScript.Instance.RequsetEnding(2);
            }
    }


    
}
