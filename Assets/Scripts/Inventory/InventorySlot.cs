using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Assets.Scripts.Dialogue;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public List<DialogueData> DialogueDatas;
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
                        UseItem();
                        return;
                        if (isSlotConsist(result.gameObject))//���Կ� �������� ��ġ�Ѵٸ�
                        {
                            
                        }
                             // ���԰� �浹�� ��� ���� �� ��
                        
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

        if (_item != null)//���� ���Կ� �������� ����ִ� ��쿡
        {
            if (_item.GetDreamGameObject().name == "RealityBottle(Get)")//���� Ŭ���϶�
            {
                if (_item.GetItemStatus() == true) //�� �������̶�� 
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[0]); // �Ų�����
                }
                else
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[1]); //������ ���..
                }
                

            }else if (_item.GetDreamGameObject().name == "JellyWarm")
            {
                if (_item.GetItemStatus() == true) //�� �������̶�� 
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[2]); // ��ȭ���
                }
                else
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[3]); // ��ȭ���
                }
            }else if (_item.GetDreamGameObject().name == "DreamBrouchMid")
            {
                if (_item.GetItemStatus() == true) //�� �������̶�� 
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[4]); // ��ȭ���
                }
                else
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[5]); // ��ȭ���
                }
            }else if (_item.GetDreamGameObject().name == "DreamBrouch4")
            {
                if (_item.GetItemStatus() == true) //�� �������̶�� 
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[6]); // ��ȭ���
                }
                else
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[7]); // ��ȭ���
                }
            }else if (_item.GetDreamGameObject().name == "DreamBrouch3")
            {
                if (_item.GetItemStatus() == true) //�� �������̶�� 
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[8]); // ��ȭ���
                }
                else
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[9]); // ��ȭ���
                }
            }else if (_item.GetDreamGameObject().name == "DreamBrouch2")
            {
                if (_item.GetItemStatus() == true) //�� �������̶�� 
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[10]); // ��ȭ���
                }
                else
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[11]); // ��ȭ���
                }
            }else if (_item.GetDreamGameObject().name == "DreamBrouch1")
            {
                if (_item.GetItemStatus() == true) //�� �������̶�� 
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[12]); // ��ȭ���
                }
                else
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[13]); // ��ȭ���
                }
            }else if (_item.GetDreamGameObject().name == "DreamKnife")
            {
                if (_item.GetItemStatus() == true) //�� �������̶�� 
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[14]); // ��ȭ���
                }
                else
                {
                    DialogueController.Instance.PlayDialogue(DialogueDatas[15]); // ��ȭ���
                }
            }
            
        }
    }


    public bool isSlotConsist(GameObject input)
    {
        if (input.name == "RealityBottle") //���� ���� input�� �̰��϶�
        {
            if (_item.GetDreamGameObject().name == "RealityBottle(Get)")//�������� ��ġ�Ѵٸ� 
            {
                return true;
            }
        }
        else if (input.name == "JellyWarm")
        {
            if (_item.GetDreamGameObject().name == "RealityWarm")//�������� ��ġ�Ѵٸ� 
            {
                return true;
            }
        }
        else if (input.name == "DreamBottle")
        {
            if (_item.GetDreamGameObject().name == "DreamBroch1")//�������� ��ġ�Ѵٸ� 
            {
                return true;
            }
        }
        else if (input.name == "RealityFlowerPot")
        {
            if (_item.GetDreamGameObject().name == "DreamBrouch4")//�������� ��ġ�Ѵٸ� 
            {
                return true;
            }
        }
        else if (input.name == "RealityFountainPen")
        {
            if (_item.GetDreamGameObject().name == "DreamKnife")//�������� ��ġ�Ѵٸ� 
            {
                return true;
            }
        }
        else if (input.name == "RealityBox")
        {
            if (_item.GetDreamGameObject().name == "DreamBrouch3")//�������� ��ġ�Ѵٸ� 
            {
                return true;
            }
        }
        else if (input.name == "RealityScrew")
        {
            if (_item.GetDreamGameObject().name == "DreamBrouchMid")//�������� ��ġ�Ѵٸ� 
            {
                return true;
            }
        }
        else if (input.name == "DreamBear")
        {
            if (_item.GetDreamGameObject().name == "DreamBrouch2")//�������� ��ġ�Ѵٸ� 
            {
                return true;
            }
        }

        return false;
    }
}
