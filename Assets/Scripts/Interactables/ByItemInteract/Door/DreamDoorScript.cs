using System.Collections.Generic;
using Assets.Scripts.Dialogue;
using UnityEngine;

public class DreamDoorScript : ClickHandler
{
    
    public TotalInventoryController TotalInventoryController;
    private bool[] _isOpen=new bool[5];

    
    public override void DoToWork()
    {
        if (TotalInventoryController.CheckAllBrouchGet())
        {
            //굳게 닫혀~~
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            DialogueController.Instance.applyDialogueOn();
            _zoomTarget.ZoomRequset();
            _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
            _zoomTarget.SwitchHitImageName("DreamDoorImage");
        }
        else
        {
            //나비모양~
            DialogueController.Instance.PlayDialogue(dialogueData[1]);
            DialogueController.Instance.applyDialogueOn();
        }
            

        
    }
    
    
    public void GetBrouchToDoor(GameObject input)
    {
        if (input.name == "DreamBrouch1")
        {
            _isOpen[0] = true;
        }
        else if (input.name == "DreamBrouch2")
        {
            _isOpen[1] = true;
        }
        else if (input.name == "DreamBrouchMid")
        {
            _isOpen[2] = true;
        }
        else if (input.name == "DreamBrouch3")
        {
            _isOpen[3] = true;
        }
        else if (input.name == "DreamBrouch4")
        {
           
            _isOpen[4] = true;
        }
        if (CheckAllBrouchInserted())
        {
            AllBrouchCollected();
        }
    }

    private void AllBrouchCollected()
    {
        //다꽃아넣
        DialogueController.Instance.PlayDialogue(dialogueData[2]);
    }
    
    private bool CheckAllBrouchInserted() //모든 브로치가 다모였는지확인 
    {
        foreach (bool isInserted in _isOpen)
        {
            if (!isInserted)
                return false;
        }
        return true;
    }
}
