using System.Collections.Generic;
using Assets.Scripts.Dialogue;
using UnityEngine;

public class DreamDoorScript : ClickHandler
{
    public bool doorIsOpen;
    public ZoomImage ZoomImage;
    public RealiryDoorScript RealiryDoorScript;
    public List<AudioClip> Clips;
    public ZoomTarget SecondZoomTarget;
    public TotalInventoryController TotalInventoryController;
    public List<SpriteRenderer> Brouchs;
    private bool[] _isOpen=new bool[5];

    
    public override void DoToWork()
    {
        if (TotalInventoryController.CheckAllBrouchGet())
        {
            
            
            //굳게 닫혀~~
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            DialogueController.Instance.applyDialogueOn();
            DialogueController.Instance.QuitButton.SetActive(false);
            _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
            for (int i = 0; i < Brouchs.Count; i++)
            {
                Brouchs[i].color = new Color(0, 0, 0, 255);
            }
            
            _zoomTarget.ZoomRequset();
            _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
            _zoomTarget.SwitchHitImageName("DreamDoorImage");
        }
        else
        {
            //나비모양~
            DialogueController.Instance.PlayDialogue(dialogueData[1]);
            EndingScript.Instance.RequsetEnding(1);
            
        }
            

        
    }
    
    
    public void GetBrouchToDoor(GameObject input)
    {
        Debug.Log(input.name);
        
        if (input.name == "DreamBroch1")
        {
            Brouchs[0].color=new Color32(255, 255, 255, 255);
            _isOpen[0] = true;
        }
        else if (input.name == "DreamBrouch2")
        {
            Brouchs[1].color=new Color32(255, 255, 255, 255);
            _isOpen[1] = true;
        }
        else if (input.name == "DreamBrouchMid")
        {
            Brouchs[2].color=new Color32(255, 255, 255, 255);
            _isOpen[2] = true;
        }
        else if (input.name == "DreamBrouch3")
        {
            Brouchs[3].color=new Color32(255, 255, 255, 255);
            _isOpen[3] = true;
        }
        else if (input.name == "DreamBrouch4")
        {
            Brouchs[4].color=new Color32(255, 255, 255, 255);
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
        DialogueController.Instance.RequestSFX(1,Clips[0]);
        SecondZoomTarget.ZoomRequset();
        _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
        RealiryDoorScript.OneFlowPlus();
        doorIsOpen = true;

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

    public void DoorOpen()
    {
        if (doorIsOpen)
        {
            for (int i = 0; i < 4; i++)
            {
                Brouchs[i].color=new Color32(0, 0, 0, 0);
            }
            
            ZoomImage.OnHide();
            doorIsOpen = false;
        }
        
    }
}
