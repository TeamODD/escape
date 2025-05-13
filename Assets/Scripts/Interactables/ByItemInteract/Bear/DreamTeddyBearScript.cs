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
        zoomImage.OnHide();
        _soundController.StartEffectBgm(KnifeSFX);
        OneFlowPlus();
        trashWarm.OneFlowPlus();
    }
  
}
