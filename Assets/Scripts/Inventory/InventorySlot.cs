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
    
    private Item _item;  // ���� ���Կ� ���� ������
    private GameObject _icon; // ������ �̹����� �� ������


    public RealityPotScript realityPotScript;
    public DreamCrowScropt dreamCrowScript;
    public DreamTeddyBearScript dreamTeddyBearScript;
    public DreamDoorScript DreamDoorScript;
   
    
    private RectTransform _rectTransform; // �̹����� ������ ���
    private Canvas _canvas; //ĵ���� ��ġ�� ������ ĵ���� 
    private Vector2 _dragOffset; // ���� �巡�� �������� 
    private Vector2 _startLoc; // ������ġ 
    private Image _iconImage; // �������̹����� ��  �̹���������Ʈ�� �� ���� 
    

    void Start()
    {
        Transform iconTransform = transform.Find("Icon");//�̸��� icon�� �ڽ���ã�Ƽ� 
        _icon = iconTransform.GetComponent<Image>().gameObject; //���� �ڽ����� ���ִ� Image������Ʈ �ֱ�
        _icon.SetActive(false);
        
        _rectTransform = _icon.GetComponent<RectTransform>(); //�� image�� rectange�� ����
        _canvas = GetComponentInParent<Canvas>(); //�θ�ĵ���� �������� 
        _iconImage=_icon.GetComponent<Image>(); //Image�� Image ������Ʈ ��������

        _targetHighlighter = background.GetComponent<Inventoryhighlighter>();
        _buttonHighlighter=button.GetComponent<Inventoryhighlighter>();
    }
    
    public void GetNewItem(Item input) //������ ������ ���ο� ������ �ֱ� 
    {
        
        _item = input;
        _icon.SetActive(true);
        if(gameObject==true)
        _targetHighlighter.OnHighlighter();
        _buttonHighlighter.OnHighlighter();
        
        UpdateSlot();//���Կ� ������ �־����ϱ� ���־� ������Ʈ
    }

    public void UseItem()  //�������� ����Ѵٸ� slot���� �Ͼ���Լ� 
    {
        
        
        //������ ��� ��ȣ�ۿ� 
        
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

    public void UpdateSlot() // ���� ���� ���� ������Ʈ 
    {
        if (_item != null) // ���� ���� �������� �����ִٸ� 
        {
            
            _icon.GetComponent<Image>().sprite = _item.GetItemIcon(); // ���� ��������  �������� �����ͼ� ������ �� ���� 
            
        }
       
    }

    public void OnItemHighLight()
    {
        if (_item != null) // ���� ���� �������� �����ִٸ� 
        {
            
            _icon.GetComponent<Image>().sprite = _item.GetHighLightIcon(); // ���� ��������  �������� �����ͼ� ������ �� ���� 
            
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

            // �巡�� ���� �������� ���콺�� ������Ʈ ���� ��ġ ���� ����
            _dragOffset = _rectTransform.anchoredPosition - localMousePos;// ���콺 ��ġ �� Canvas ���� ��ǥ�� ��ȯ
            
            
        }

        
        
        
        //transform.SetAsLastSibling();

        
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        _targetHighlighter.OffHighliter();
        _buttonHighlighter.OffHighliter();
        if (isZoomMode && _item != null)
        {
            // ���콺 ��ġ �� Canvas ���� ��ǥ�� ��ȯ
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
           
            
            

            // ���� ���콺 ��ġ�� ĵ���� ���� ��ǥ�� ��ȯ
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
                    if (result.gameObject.name==targetUseItem.name) // ��: ���԰� �浹�ߴ���
                    {
                        if (true) //�װ� �ܻ��¿��� ������ ��ȣ�ۿ����� ��
                        {
                            UseItem();
                            return; // ���԰� �浹�� ��� ���� �� ��
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
