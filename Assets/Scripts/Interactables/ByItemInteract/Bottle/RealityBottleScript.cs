using Assets.Scripts.Dialogue;
using UnityEngine;
using UnityEngine.Events;

public class RealityBottleScript : ClickHandler
{
    public GameObject ZoomImage;
    [field:SerializeField] public UnityEvent OnFade { get; private set; }
    public ClickHandler dreamDrawer;
    public DreamBolttleScript DreamBolttleScript;
    public bool isDrink=false;
    public bool isSelectEatOrGet = false;
    public bool isPlayerDeath;
    public override void DoToWork()
    {
        if (flowIdx == 0)
        {
            //금이 가 있는 빈병이다
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
        }
        else if (flowIdx == 1) //물이 채워진 상태에서 
        {
            //뭐지? 분명~~
            if (isSelectEatOrGet)
            {
                DialogueController.Instance.PlayDialogue(dialogueData[4]);
                DialogueController.Instance.applyDialogueOn();
                _zoomTarget.ZoomRequset();
                _zoomTarget._selectButtonController.SwithchAllButtonStatus(true);
            }
            else
            {
                DialogueController.Instance.PlayDialogue(dialogueData[1]);
                DialogueController.Instance.applyButtonOn(4);
                _zoomTarget.ZoomRequset();
            }
            
            
        }
        else if (flowIdx == 2)
        {
            
        }

        
    }
    public void RequestZoom()
    {
        _zoomTarget.ZoomRequset();
       
        

    }

    public void PlayerSelectDrinkPoison()
    {
        
        //죽음 엔딩 처리 
        _isGetEnd = true;
       
      
        OnFade.Invoke();
        flowIdx++;
        ChangeSprite(flowIdx);
        CheckFlowIsFinish();
    }

    public void PlayerDie()
    {
        GameManager.Instance.Inventorycanvas.SetActive(false);
        DialogueController.Instance.PlayDialogue(dialogueData[3]);
        isPlayerDeath = true;
    }

    public void GotoLobby()
    {
        if (isPlayerDeath)
        {
            isPlayerDeath = false;
            GameManager.Instance.LoadScene();
        }
    }
    
    public void PlayerSelectGetBottle()
    {
        dreamDrawer.OneFlowPlus();
        DreamBolttleScript.OneFlowPlus();
       // DreamBolttleScript.OneFlowPlus();
        OneFlowPlus();
        flowController.CheckGameObject(gameObject);
    }

    public void PlayerSelectDontDrink()
    {
        isSelectEatOrGet = true;
        RequestZoom();
    
        //아무래도 해골마크..
        
        DialogueController.Instance.PlayDialogue(dialogueData[2]);//자막이 꺼지기 전에 다시 시작해서 appyl button  안됨
        DialogueController.Instance.applyButtonOn(1);
    }
}
