using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    
    public bool isZoomMode;
    public GameObject button;
    public GameObject background;

    public GameObject targetUseItem;
    
    private Inventoryhighlighter _buttonHighlighter;
    private Inventoryhighlighter _targetHighlighter;
    
    private Item _item;  // 현재 슬롯에 사용될 아이템
    private GameObject _icon; // 아이템 이미지가 뜰 아이콘


    public RealityPotScript realityPotScript;
    public DreamCrowScropt dreamCrowScript;
    public DreamTeddyBearScript dreamTeddyBearScript;
    public DreamDoorScript DreamDoorScript;
   
    
    private RectTransform _rectTransform; // 이미지를 잡을때 사용
    private Canvas _canvas; //캔버스 위치를 참고할 캔버스 
    private Vector2 _dragOffset; // 현재 드래그 길이차이 
    private Vector2 _startLoc; // 시작위치 
    private Image _iconImage; // 아이템이미지가 들어갈  이미지컴포넌트가 들어갈 변수 
    

    void Start()
    {
        Transform iconTransform = transform.Find("Icon");//이름이 icon인 자식을찾아서 
        _icon = iconTransform.GetComponent<Image>().gameObject; //현재 자식으로 들어가있는 Image오브젝트 넣기
        _icon.SetActive(false);
        
        _rectTransform = _icon.GetComponent<RectTransform>(); //그 image의 rectange값 저장
        _canvas = GetComponentInParent<Canvas>(); //부모캔버스 가져오기 
        _iconImage=_icon.GetComponent<Image>(); //Image의 Image 컴포넌트 가져오기

        _targetHighlighter = background.GetComponent<Inventoryhighlighter>();
        _buttonHighlighter=button.GetComponent<Inventoryhighlighter>();
    }
    
    public void GetNewItem(Item input) //아이템 변수에 새로운 아이템 넣기 
    {
        
        _item = input;
        _icon.SetActive(true);
        if(gameObject==true)
        _targetHighlighter.OnHighlighter();
        _buttonHighlighter.OnHighlighter();
        
        UpdateSlot();//슬롯에 아이템 넣었으니까 비주얼 업데이트
    }

    public void UseItem()  //아이템을 사용한다면 slot에서 일어나는함수 
    {
        
        
        //아이템 사용 상호작용 
        
        if (targetUseItem.name == "RealityPotImage")
        {
            realityPotScript.GetPoison();
        }
        else if (targetUseItem.name == "DreamCrowImage")
        {
            dreamCrowScript.GetWarm();
        }
        else if (targetUseItem.name == "DreamBearImage")
        {
            dreamTeddyBearScript.GetKnife();
        }
        else if (targetUseItem.name == "DreamDoorImage")
        {
            DreamDoorScript.GetBrouchToDoor(_item.ExtractItem());
            
            //dreamTeddyBearScript.GetKnife();
        }
        
        _item = null;
        _icon.GetComponent<Image>().sprite = null;
        _icon.SetActive(false);
        
    }

    public void UpdateSlot() // 현재 슬롯 상태 업데이트 
    {
        if (_item != null) // 만약 현재 아이템이 들어와있다면 
        {
            
            _icon.GetComponent<Image>().sprite = _item.GetItemIcon(); // 현재 아이템의  아이콘을 가져와서 아이콘 에 저장 
            
        }
       
    }

    public void OnItemHighLight()
    {
        if (_item != null) // 만약 현재 아이템이 들어와있다면 
        {
            
            _icon.GetComponent<Image>().sprite = _item.GetHighLightIcon(); // 현재 아이템의  아이콘을 가져와서 아이콘 에 저장 
            
        }
    }
    public void SwitchItem(bool status)
    {
        if(_item!=null)
            _item.SwitchItemStatus(status);
       
        UpdateSlot();
    }

  

    public void OnBeginDrag(PointerEventData eventData)
    {
        _targetHighlighter.OffHighliter();
        _buttonHighlighter.OffHighliter();
        if (isZoomMode && _item != null)
        {
            
            
            _iconImage.maskable=false;
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                eventData.position,
                _canvas.worldCamera,
                out Vector2 localMousePos
            );
            _startLoc = localMousePos;

            // 드래그 시작 시점에서 마우스와 오브젝트 간의 위치 차이 저장
            _dragOffset = _rectTransform.anchoredPosition - localMousePos;// 마우스 위치 → Canvas 로컬 좌표로 변환
            
            
        }

        
        
        
        //transform.SetAsLastSibling();

        
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        _targetHighlighter.OffHighliter();
        _buttonHighlighter.OffHighliter();
        if (isZoomMode && _item != null)
        {
            // 마우스 위치 → Canvas 로컬 좌표로 변환
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _canvas.transform as RectTransform,
                    eventData.position,
                    _canvas.worldCamera,
                    out Vector2 localMousePos
                ))
            {
                _rectTransform.anchoredPosition = localMousePos + _dragOffset;
            }
        }
            
        
        
      
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (isZoomMode && _item != null)
        {
            _iconImage.maskable = true;
           
            
            

            // 현재 마우스 위치를 캔버스 로컬 좌표로 변환
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _canvas.transform as RectTransform,
                    eventData.position,
                    _canvas.worldCamera,
                    out Vector2 endLoc
                ))
            {
                List<RaycastResult> results = new List<RaycastResult>();

                PointerEventData pointerData = new PointerEventData(EventSystem.current)
                {
                    position = eventData.position
                };

                EventSystem.current.RaycastAll(pointerData, results);

                foreach (RaycastResult result in results)
                {
                    Debug.Log(result);
                    if (result.gameObject.name==targetUseItem.name) // 예: 슬롯과 충돌했는지
                    {
                        if (true) //그게 줌상태에서 가능한 상호작용인지 비교
                        {
                            UseItem();
                            return; // 슬롯과 충돌한 경우 복귀 안 함
                        }
                        
                    }
                }

                _rectTransform.anchoredPosition = _startLoc + _dragOffset;
                
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        OnItemHighLight();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        UpdateSlot();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _targetHighlighter.OffHighliter();
        _buttonHighlighter.OffHighliter();
    }
    
}
