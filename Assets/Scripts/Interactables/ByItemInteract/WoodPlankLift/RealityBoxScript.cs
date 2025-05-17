using Assets.Scripts.Dialogue;
using UnityEngine;
using UnityEngine.Events;

public class RealityBoxScript : ClickHandler
{
    [field:SerializeField] public UnityEvent OnStartPuzzle { get; private set; }
    public AudioClip openSFX;
    public DreamButtonScript DreamButtonScript;
    [field:SerializeField] public UnityEvent OnCompletePuzzle { get; private set; }
    private bool _isCanGetKey;
    
    private bool _isRequestItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void DoToWork()
    {
         if (flowIdx == 1)
        {
            //바닥의판자
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
           
            DreamButtonScript.isBoxOpened=true; 
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
            
        }
        
    }

    public void BoxSolve()
    {
        DialogueController.Instance.PlayDialogue(dialogueData[1]);
        SoundControllerScript.Instance.StartEffectBgm(openSFX);
        OneFlowPlus();
      
        _isCanGetKey = true;
    }


    public void GetKey()
    {
        if (_isCanGetKey)
        {
            _isCanGetKey=false;
            flowController.CheckGameObject(gameObject); 
            //퍼즐 비활성화
            OnCompletePuzzle.Invoke();
        }
        
    }
}
