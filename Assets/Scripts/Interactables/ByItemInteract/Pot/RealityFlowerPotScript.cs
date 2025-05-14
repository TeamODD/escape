using Assets.Scripts.Dialogue;
using UnityEngine;

public class RealityFlowerPotScript : ClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void DoToWork()
    {
        
        if (flowIdx == 1)
        {
            //햇빛을 양껏..
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            flowController.CheckGameObject(gameObject);
            flowIdx++;

        }
    }
    
}
