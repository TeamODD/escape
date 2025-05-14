using Assets.Scripts.Dialogue;
using UnityEngine;

public class DreamBolttleScript : ClickHandler
{
    public ClickHandler dreamDrawer;
    public bool isDrink=false;
    public RealityBottleScript realityBottleScript;
    
    public override void DoToWork()
    {

        if (flowIdx == 0)
        {
            _zoomTarget.ZoomRequset();
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            DialogueController.Instance.applyButtonOn(4);
        }
        else if (flowIdx ==1 )
        {
            
            flowController.CheckGameObject(gameObject);
            flowIdx++;
        }
        else if (flowIdx == 2)
        {
            DialogueController.Instance.PlayDialogue(dialogueData[1]);
        }
      
    }

    public void DrinkDreamBottle()
    {
        
        SwitchisEnableZoom(false);
        OneFlowPlus();
        realityBottleScript.OneFlowPlus();
        dreamDrawer.OneFlowPlus();
        
    }
}
