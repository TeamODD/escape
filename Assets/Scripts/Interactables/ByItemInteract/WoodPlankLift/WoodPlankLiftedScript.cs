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
            SoundControllerScript.Instance.StartEffectBgm(shakeSFX);
           
            
            
            
            
            
            
            
            flowIdx++;
            
        }
        else if(flowIdx==4)
        {
            CrackWood.SetActive(true);
            realityBoxScript.OneFlowPlus();
            realityBoxScript.GetComponent<SpriteRenderer>().sortingOrder = 4;
            ChangeSprite(flowIdx);
            SoundControllerScript.Instance.StartEffectBgm(crackSFX);
            
            flowIdx++;
        }
    }
}
