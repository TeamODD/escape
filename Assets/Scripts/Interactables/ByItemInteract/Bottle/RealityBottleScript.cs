using UnityEngine;

public class RealityBottleScript : ClickHandler
{
    public bool isDrink=false;
    public bool isSelectEatOrGet = false;
    public override void DoToWork()
    {
        
       
           //줌인 시도하는 코드 삽입 마신다 안마신다 
       
        //줌인 코드 삽입 하면 됨 지금은 바로 비활성화 
        if (flowIdx == 1) //isdrink가 true가 되면  flow증가
        {
            _zoomTarget.ZoomRequset();
        }
    
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
        OneFlowPlus();
        flowController.CheckGameObject(gameObject);
    }
}
