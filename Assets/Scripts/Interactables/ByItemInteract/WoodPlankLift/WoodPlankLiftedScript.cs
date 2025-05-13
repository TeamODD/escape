using UnityEngine;

public class WoodPlankLiftedScript : ClickHandler
{
    public AudioClip shakeSFX;
    public AudioClip crackSFX;
    public RealityBoxScript realityBoxScript;
    public override void DoToWork()
    {
        if (flowIdx <= 3)
        {
            _soundController.StartEffectBgm(shakeSFX);
            flowIdx++;
            
        }
        else if(flowIdx==4)
        {
            realityBoxScript.OneFlowPlus();
            ChangeSprite(flowIdx);
            _soundController.StartEffectBgm(crackSFX);

        }
    }
}
