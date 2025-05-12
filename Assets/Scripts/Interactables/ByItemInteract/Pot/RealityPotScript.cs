using Unity.VisualScripting;
using UnityEngine;

public class RealityPotScript : ClickHandler
{
    public AudioClip WaterSFX;
    private float _timer = 0f;
    void Update()
    {
        if (flowIdx == 1)
        {
            _timer += Time.deltaTime; // 프레임당 경과시간 누적

            if (_timer >= 2f) // 2초 지났으면
            {
                Debug.Log("shake shake");
                //흔들흔들 애니메이션 추가
                _timer = 0f; // 타이머 초기화
            }
        }
        else
        {
            _timer = 0f; // flowIdx가 바뀌면 타이머도 리셋
        }
    }
    
    public override void DoToWork()
    {
        
        if (flowIdx == 1)
        {
            
            flowController.CheckGameObject(gameObject); 
            //애벌래 획득 스크립트 등장
            flowIdx++;
            ChangeSprite(flowIdx);
        }
        
        
        
    }

    public void GetPoison()
    {
        _soundController.StartEffectBgm(WaterSFX);
        flowIdx++;
        ChangeSprite(flowIdx);
    }
    
}
