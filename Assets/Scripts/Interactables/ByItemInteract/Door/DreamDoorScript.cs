using UnityEngine;

public class DreamDoorScript : ClickHandler
{
    public TotalInventoryController TotalInventoryController;
    public override void DoToWork()
    {
        if (TotalInventoryController.CheckAllBrouchGet())
        {
            _zoomTarget.ZoomRequset();
            _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
            _zoomTarget.SwitchHitImageName("DreamDoorImage");
        }
            

        
    }
    
    
    public void GetBrouchToDoor(GameObject input)
    {
        if (input.name == "DreamBrouch1") //브로치 1부터
        {
            
        }
        else if (input.name == "DreamBrouch2")
        {
            
        }
        else if (input.name == "DreamBrouchMid")
        {
            
        }
        else if (input.name == "DreamBrouch3")
        {
            
        }
        else if (input.name == "DreamBrouch4")//브로치 5까지
        {
            
        }
        
    }
}
