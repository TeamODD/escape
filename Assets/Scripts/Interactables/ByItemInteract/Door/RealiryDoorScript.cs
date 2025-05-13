using UnityEngine;

public class RealiryDoorScript : ClickHandler
{
    public override void DoToWork()
    {
        
            _zoomTarget.ZoomRequset();
            _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
            _zoomTarget.SwitchHitImageName("ReailtyDoor");

        
    }


    
}
