using Assets.Scripts.Dialogue;
using UnityEngine;

public class RealityScrewScript : ClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void DoToWork()
    {
        if (flowIdx == 1)
        {
            //스테인글라스의
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            flowController.CheckGameObject(gameObject); 
            OneFlowPlus();
        }
    }
}
