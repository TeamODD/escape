using Assets.Scripts.Dialogue;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class RealityPotScript : ClickHandler
{
    [field:SerializeField] public UnityEvent Shaking { get; private set; }
    public ZoomTarget secondZoomTarget;
    public AudioClip WaterSFX;
    public ZoomImage ZoomImage;
    private float _timer = 0f;
    private bool _isRequestItem;
    void Update()
    {
       
        
        
        if (flowIdx == 1)
        {
            _timer += Time.deltaTime; // 프레임당 경과시간 누적

            if (_timer >= 2f) // 2초 지났으면
            {
                Shaking.Invoke();
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
        if (flowIdx == 0)
        {
            //잡초가 무성하게~~
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            DialogueController.Instance.applyDialogueOn();
            _zoomTarget.ZoomRequset();
            _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
            _zoomTarget.SwitchHitImageName("RealityPotImage");

        }
        else if (flowIdx == 1)
        {
            
            DialogueController.Instance.OnCompleted.Invoke();
            //아무것도 없을~~
            DialogueController.Instance.PlayDialogue(dialogueData[1]);
            _isRequestItem = true;
            //애벌래 획득 스크립트 등장
            flowIdx++;
            ChangeSprite(flowIdx);
        }
        else if (flowIdx == 2)
        {
            //흙밖에 없는~~
            DialogueController.Instance.PlayDialogue(dialogueData[3]);
        }
        
        
        
    }

    public void GetPoison()
    {
        //물병의 액체~
        _isRequestItem = true;
        secondZoomTarget.ZoomRequset();
        _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
        
        DialogueController.Instance.PlayDialogue(dialogueData[2]);
        _soundController.StartEffectBgm(WaterSFX);
        //ZoomImage.OnHide();
        
        flowIdx++;
        ChangeSprite(flowIdx);
    }

    public void GetWarm()
    {
        if (_isRequestItem )
        {
            
            ZoomImage.OnHide();
            flowController.CheckGameObject(gameObject);
            _isRequestItem = false;
        }
        
    }
}
