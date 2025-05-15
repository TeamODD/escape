using System.Collections.Generic;
using Assets.Scripts.Dialogue;
using UnityEditor.Rendering;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    
    public List<GameObject> flowObjects = new List<GameObject>();
    public List<GameObject> lastDoors = new List<GameObject>();
    
    public TotalInventoryController inventory;


    public List<DialogueData> DialogueDatas;
    private int _flowIndex;
    private int _gameSwitchCount;
    private GameObject _currentSelectObject;
    private GameObject _previousObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _flowIndex = 0;
        _gameSwitchCount = 0;
        _currentSelectObject = null;
        _previousObject = null;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckSwitch()
    {
        _gameSwitchCount++;
        Debug.Log(_gameSwitchCount);
        if (_flowIndex==0&&_gameSwitchCount >= 8) // 아직 히든앤딩이 가능하고 꿈 현실 변환도 4번 이상하면 
        {
            //히든 앤딩
            DialogueController.Instance.PlayDialogue(DialogueDatas[0]);
            EndingScript.Instance.RequsetEnding(0);
        }
        else if (_gameSwitchCount >= 15) // 히든엔딩이 안되지만 4번이상
        {
            //배드엔딩
            DialogueController.Instance.PlayDialogue(DialogueDatas[1]);
            EndingScript.Instance.RequsetEnding(1);
        }
    }
    public void CheckGameObject(GameObject input)
    {
        
        _currentSelectObject = input;
      
        
       
        inventory.CheckCanInsertObject(_currentSelectObject);
        
            _flowIndex++; 
            
          
        
        
    }
    
    
   
}