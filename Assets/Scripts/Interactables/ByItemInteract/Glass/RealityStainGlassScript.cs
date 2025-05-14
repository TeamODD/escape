using Assets.Scripts.Dialogue;
using Unity.VisualScripting;
using UnityEngine;

public class RealityStainGlass : ClickHandler
{

    public override void DoToWork()
    {
        if (flowIdx==0)
        {
            //까마귀가 그려진
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
        }
        else if (flowIdx == 1)
        {
            //기분햇
            DialogueController.Instance.PlayDialogue(dialogueData[1]);
        }

    }

    
   
} 
