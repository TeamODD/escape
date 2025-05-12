using UnityEngine;

public class DreamBolttleScript : ClickHandler
{
    public bool isDrink=false;
    public RealityBottleScript realityBottleScript;
    public override void DoToWork()
    {
       
        if (flowIdx == 0)
        {
            flowIdx++;
            ChangeSprite(flowIdx);
            CheckFlowIsFinish();
            realityBottleScript.PlayerDrinkInDream();
            
        }
        else if (flowIdx == 1)
        {
            //마신다 안마신다 
            SetcanExamineFlow(true);
        }
       
    }
}
