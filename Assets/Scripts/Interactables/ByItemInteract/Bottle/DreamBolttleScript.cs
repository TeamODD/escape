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
        }
        else if (flowIdx == 1)
        {
            
            flowController.CheckGameObject(gameObject);
            
        }
      
    }

    public void DrinkDreamBottle()
    {
        Debug.Log("Drink!");
        SwitchisEnableZoom(false);
        OneFlowPlus();
        realityBottleScript.OneFlowPlus();
        dreamDrawer.OneFlowPlus();
        
    }
}
