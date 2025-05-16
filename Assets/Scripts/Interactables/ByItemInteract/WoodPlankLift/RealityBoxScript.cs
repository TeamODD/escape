using Assets.Scripts.Dialogue;
using UnityEngine;
using UnityEngine.Events;

public class RealityBoxScript : ClickHandler
{
    [field:SerializeField] public UnityEvent OnStartPuzzle { get; private set; }
    public AudioClip openSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void DoToWork()
    {
         if (flowIdx == 1)
        {
            //바닥의판자
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
           
            
            OnStartPuzzle.Invoke();
            //퍼즐 진행 
            //상자 퍼즐 진행 성공했다 치고
            flowIdx++;
        }
         else if(flowIdx==2)
         {
             OnStartPuzzle.Invoke();
         }
        else if (flowIdx == 3)
        {
            //상자가열렷다
            DialogueController.Instance.PlayDialogue(dialogueData[1]);
            _soundController.StartEffectBgm(openSFX);
            ChangeSprite(flowIdx);
            flowController.CheckGameObject(gameObject); 
        }
        
    }
}
