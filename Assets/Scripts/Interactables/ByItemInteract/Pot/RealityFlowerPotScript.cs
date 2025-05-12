using UnityEngine;

public class RealityFlowerPotScript : ClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void DoToWork()
    {
        Debug.Log("input");
        if (flowIdx == 1)
        {
            flowController.CheckGameObject(gameObject);
            OneFlowPlus();
            
        }
    }
    
}
