using UnityEngine;

public class RealityBottleScript : ClickHandler
{
    public bool isDrink=false;
    public override void DoToWork()
    {
       
       
           //줌인 시도하는 코드 삽입 마신다 안마신다 
       
        //줌인 코드 삽입 하면 됨 지금은 바로 비활성화 
        if (flowIdx == 1) //isdrink가 true가 되면  flow증가
        {
            flowIdx++;
            ChangeSprite(flowIdx);
            flowController.CheckGameObject(gameObject);
        }
    
    }
    

    public void PlayerDrinkInDream()
    {
        flowIdx++;
        ChangeSprite(flowIdx);
        CheckFlowIsFinish();
    }
}
