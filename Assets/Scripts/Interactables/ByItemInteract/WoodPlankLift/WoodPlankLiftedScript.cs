using UnityEngine;

public class WoodPlankLiftedScript : ClickHandler
{
    public GameObject CrackWood;
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
            CrackWood.SetActive(true);
            realityBoxScript.OneFlowPlus();
            realityBoxScript.GetComponent<SpriteRenderer>().sortingOrder = 4;
            ChangeSprite(flowIdx);
            _soundController.StartEffectBgm(crackSFX);
            flowIdx++;
        }
    }
}
