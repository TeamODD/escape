using UnityEngine;
using UnityEngine.Events;

public class DreamButtonScript : ClickHandler
{
    public AudioClip changeSFX;
    [field:SerializeField] public UnityEvent OnSwitchPattern { get; private set; }
    public bool isBoxOpened;
    public override void DoToWork()
    {
        SoundControllerScript.Instance.StartEffectBgm(changeSFX);
        flowIdx++;
        if (flowIdx >= 3)
        {
            flowIdx = 0;
        }
        ChangeSprite(flowIdx);

        if (isBoxOpened)
        {
            OnSwitchPattern.Invoke();
        }
        
        
        if (flowIdx == 0)
        {
            
        }
        else if (flowIdx == 1)
        {
            
        }
        else if (flowIdx == 2)
        {
            
        }
       
        
        
    }

    public void SwitchIdx(int idx)
    {
        
    }
    
    
}
