using UnityEngine;
using UnityEngine.Events;

public class DreamButtonScript : ClickHandler
{
    [field:SerializeField] public UnityEvent OnSwitchPattern { get; private set; }
    public override void DoToWork()
    {

        flowIdx++;
        if (flowIdx >= 3)
        {
            flowIdx = 0;
        }
        ChangeSprite(flowIdx);
        
        OnSwitchPattern.Invoke();
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
