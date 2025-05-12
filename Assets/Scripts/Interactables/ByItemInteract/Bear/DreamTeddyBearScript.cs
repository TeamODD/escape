using UnityEngine;

public class DreamTeddyBearScript : ClickHandler
{
    public ClickHandler trashWarm;
    public AudioClip KnifeSFX;
    public override void DoToWork()
    {
        if (flowIdx == 1)
        {
            flowController.CheckGameObject(gameObject);
            
        }
    }

    public void GetKnife()
    {
        _soundController.StartEffectBgm(KnifeSFX);
        OneFlowPlus();
        trashWarm.OneFlowPlus();
    }
  
}
