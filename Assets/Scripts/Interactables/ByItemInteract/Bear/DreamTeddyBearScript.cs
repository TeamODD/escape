using UnityEngine;

public class DreamTeddyBearScript : ClickHandler
{
    public override void DoToWork()
    {
        if (flowIdx == 1)
        {
            flowController.CheckGameObject(gameObject);
        }
    }

    public void GetKnife()
    {
        OneFlowPlus();
        
    }
  
}
