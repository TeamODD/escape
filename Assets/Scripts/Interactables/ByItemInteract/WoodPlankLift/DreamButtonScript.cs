using UnityEngine;
using UnityEngine.Events;

public class DreamButtonScript : ClickHandler
{
    public Testing testingScript;
    public AudioClip changeSFX;
    [field:SerializeField] public UnityEvent OnSwitchPattern { get; private set; }
    public bool isBoxOpened;
    public override void DoToWork()
    {
        flowIdx++;
        if (flowIdx >= 3)
        {
            flowIdx = 0;
        }
        
        if (isBoxOpened)
        {
            SoundControllerScript.Instance.StartEffectBgm(changeSFX);
            OnSwitchPattern.Invoke();
            ChangeSprite(flowIdx);
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
