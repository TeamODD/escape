using System.Collections.Generic;
using Assets.Scripts.Dialogue;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonController : MonoBehaviour
{
    public List<DialogueData> dialogueDatas;
    
    
    
    
    
    
    public ButtonTextScript LeftText;
    public ButtonTextScript RightText;
    public GameObject leftButton;
    public GameObject rightButton;
    public ZoomImage zoomImage;
    public List<GameObject> SelectedList;
    private int selectedAnswer;
   
    private GameObject _currentSelectedObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void SwithchAllButtonStatus(bool Status)
    {
        leftButton.SetActive(Status);
        rightButton.SetActive(Status);
    }

    public void SetAnswerInt(GameObject Target) // 현재 질문을 요청하는 객체를 찾아 해당 인덱스에 맞게 상호작용
    {
        _currentSelectedObject = Target;
        selectedAnswer=SelectedList.IndexOf(Target);
        SetText();
    }

    public void SetText()
    {
        switch (selectedAnswer)
        {
            case 0: //현실문
            {
                
                
                
                break;
            }
            case 1: //꿈곰
            {
               
                break;
            }
            case 2: //꿈 물병 
            {
                LeftText.SetText("마신다");
                RightText.SetText("안마신다 ");
                
                break;
            }
            case 3:// 꿈 까마귀
            {
                
                break;
            }
            case 4: //현실 물병 
            {
                RealityBottleScript realityBottleScript = _currentSelectedObject.GetComponent<RealityBottleScript>();
                
                if(!realityBottleScript.isSelectEatOrGet) //마실거냐 안마실거냐 선택을 햇는지 
                { //마실거냐 
                    
                    LeftText.SetText("마신다");
                    RightText.SetText("안마신다 ");
                } // 안마실거냐 
                else
                {
                    LeftText.SetText("챙긴다");
                    RightText.SetText("안챙긴다 ");
                }
               
                break;
            }
            case 5: //현실 박스 
            {
                break;
            }
            case 6: //현실 꽃병
            {
                
                break;
            }
            
        }
    }
    public void GetAnswer(bool answer) //왼쪽 대답이 false오른쪽대답이 true
    {
      
        
        zoomImage.OnHide(); //대답을 받으면 사라진다 
        LeftText.SetText("");
        RightText.SetText("");
        switch (selectedAnswer)
        {
            case 0: //현실문
            {
                if (answer)
                {
                    Debug.Log("오른쪽 선택 ");
                }
                else
                {
                    Debug.Log("왼쪽 선택 ");
                }
                
                
                break;
            }
            case 1: //꿈곰
            {
                if (answer)
                {
                    
                }
                else
                {
                    
                }
                break;
            }
            case 2: //꿈 물병 
            {
                
                if (answer) //안마신다 
                {
                    //dreamBottleDontDrinkDialogue
                    DialogueController.Instance.PlayDialogue(dialogueDatas[0]);
                }
                else //마신다 
                {
                    //dreamBottleDrinkDialogue
                    DialogueController.Instance.PlayDialogue(dialogueDatas[1]);
                    DreamBolttleScript dreamBolttleScript = _currentSelectedObject.GetComponent<DreamBolttleScript>();
                    dreamBolttleScript.DrinkDreamBottle();
                }
                break;
            }
            case 3:// 꿈 까마귀
            {
                if (answer)
                {
                    
                }
                else
                {
                    
                }
                break;
            }
            case 4: //현실 물병 
            {
                RealityBottleScript realityBottleScript = _currentSelectedObject.GetComponent<RealityBottleScript>();
                
                if(!realityBottleScript.isSelectEatOrGet) //마실거냐 안마실거냐 선택을 햇는지 
                { //마실거냐 
                    
                    if (answer)//안마신다
                    {
                        realityBottleScript.PlayerSelectDontDrink();
                      
                        
                        
                    }
                    else //마신다 
                    {
                        //아무맛도나지~~
                        DialogueController.Instance.PlayDialogue(dialogueDatas[3]);
                        realityBottleScript.PlayerSelectDrinkPoison();
                    }
                } // 안마실거냐 
                else //맨처음에 
                {
                   
                    if (answer) //안챙기냐 
                    {
                        //꺼림칙하니~~
                        DialogueController.Instance.PlayDialogue(dialogueDatas[4]);
                    }
                    else//챙기냐 
                    {
                        Debug.Log("get");
                        //어딘가~~
                        DialogueController.Instance.PlayDialogue(dialogueDatas[5]);
                        realityBottleScript.PlayerSelectGetBottle();
                    }
                }
               
                break;
            }
            case 5: //현실 박스 
            {
                if (answer)
                {
                    
                }
                else
                {
                    
                }
                break;
            }
            case 6: //현실 꽃병
            {
                
                if (answer)
                {
                    
                }
                else
                {
                    
                }
                break;
            }
            
        }
    }
}
