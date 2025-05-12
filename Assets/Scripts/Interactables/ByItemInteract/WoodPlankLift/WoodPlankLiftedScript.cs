using UnityEngine;

public class WoodPlankLiftedScript : ClickHandler
{
    public AudioClip crackSFX;
    public RealityBoxScript realityBoxScript;
    public override void DoToWork()
    {
        if (flowIdx <= 3)
        {
            flowIdx++;
            
        }
        else
        {
            realityBoxScript.OneFlowPlus();
            ChangeSprite(flowIdx);
            _soundController.StartEffectBgm(crackSFX);

        }
    }
}
