using Assets.Scripts.Dialogue;
using UnityEngine;
using UnityEngine.Events;

public class RealiryDoorScript : ClickHandler
{
    
    [field:SerializeField] public UnityEvent OnFade { get; private set; }
    public override void DoToWork()
    {
        //문은굳게 닫혀있다
        
            


            if (flowIdx == 0)
            {
                DialogueController.Instance.PlayDialogue(dialogueData[0]);
                
                
                
            }
            else if (flowIdx==1)
            {
                OnFade.Invoke();
                //현실로 나가는 엔딩 출력부분
               
            }

          
    }
    public void EndingStart()
    {
        DialogueController.Instance.PlayDialogue(dialogueData[1]);
        EndingScript.Instance.RequsetEnding(2);
    }

    
}
