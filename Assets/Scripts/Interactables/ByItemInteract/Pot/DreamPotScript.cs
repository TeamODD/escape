using Assets.Scripts.Dialogue;
using UnityEngine;

public class DreamPotScript : ClickHandler
{
    public override void DoToWork()
    {
        if (flowIdx == 0)
        {
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
        }
        else if (flowIdx == 1)
        {
            DialogueController.Instance.PlayDialogue(dialogueData[1]);
        }
    }
}
