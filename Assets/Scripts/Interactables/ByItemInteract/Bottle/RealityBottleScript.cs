using Assets.Scripts.Dialogue;
using UnityEngine;

public class RealityBottleScript : ClickHandler
{
    public GameObject ZoomImage;
    
    public ClickHandler dreamDrawer;
    public DreamBolttleScript DreamBolttleScript;
    public bool isDrink=false;
    public bool isSelectEatOrGet = false;
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
            DialogueController.Instance.PlayDialogue(dialogueData[1]);
            DialogueController.Instance.applyButtonOn(4);
            _zoomTarget.ZoomRequset();
            
            
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
        flowIdx++;
        ChangeSprite(flowIdx);
        CheckFlowIsFinish();
    }

    public void PlayerSelectGetBottle()
    {
        dreamDrawer.OneFlowPlus();
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
