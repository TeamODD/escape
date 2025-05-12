using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    public List<Sprite> imageList;
    public FlowController flowController;
    protected  bool canExamineFlow = false;
    private SpriteRenderer _spriteRenderer;

    protected int flowIdx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        flowIdx = 0;
        if (imageList.Count == 0)
        {
            
            canExamineFlow = true;
            
        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        EventTrigger trigger = GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }

        // PointerClick 이벤트 생성
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(OnPointerClicked); // <- 이 부분 중요!

        // 트리거에 이벤트 추가
        trigger.triggers.Add(entry);
    }
    public void OnPointerClicked(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

       
        CheckIsExsistDo();
        
    }
    
    void Update()
    {
        
    }

    public void CheckIsExsistDo()
    {
        
        
        if (canExamineFlow)
        {
            flowController.CheckGameObject(gameObject); 
        }
        else
        {
            DoToWork();
        }
    }

    
    
    public void SetcanExamineFlow(bool input)
    {
        canExamineFlow = input;
    }
    public virtual void DoToWork()
    {
       
    }

    public void ChangeSprite(int targetIdx)
    {
        
        _spriteRenderer.sprite = imageList[targetIdx];
        
    }

    public void OneFlowPlus()
    {
        flowIdx++;
        ChangeSprite(flowIdx);
    }
    public void CheckFlowIsFinish()
    {
        if (flowIdx+1 == imageList.Count)
        {
            SetcanExamineFlow(true);
        }
    }
}
