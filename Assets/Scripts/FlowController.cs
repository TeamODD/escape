using System.Collections.Generic;
using Assets.Scripts.Dialogue;
using UnityEngine;
using UnityEngine.Events;

public class FlowController : MonoBehaviour
{
    
  
    
    public TotalInventoryController inventory;


    public List<DialogueData> DialogueDatas;
    public int _flowIndex;
    private int _gameSwitchCount;
    private GameObject _currentSelectObject;
    private GameObject _previousObject;
    private bool _isGetEnd;
    [field:SerializeField] public UnityEvent OnHiddenStart { get; private set; }
    [field:SerializeField] public UnityEvent OnBedStart { get; private set; }
    
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
       
        // 아무것도 안건들고
        //꿈  현실 상태 변환 몇번 ?
        //아무것도 좀 빡세 아이템획득이나 줌안하는거 이걸로 ㄱㄱ
        //
        if (_flowIndex==0&&_gameSwitchCount >= 2) // 아직 히든앤딩이 가능하고 꿈 현실 변환도 4번 이상하면 
        {
            //히든 앤딩
            OnHiddenStart.Invoke();
            StartHiddenEnding();
        }
        else if (_gameSwitchCount >= 15) // 히든엔딩이 안되지만 4번이상
        {
            //배드엔딩
            OnBedStart.Invoke();
            StartBedEnding();
        }
    }
    
    public void StartHiddenEnding()
    {
        DialogueController.Instance.PlayDialogue(DialogueDatas[0]);
        EndingScript.Instance.RequsetEnding(0);
        _isGetEnd = true;
    }
    public void StartBedEnding()
    {
        DialogueController.Instance.PlayDialogue(DialogueDatas[1]);
        EndingScript.Instance.RequsetEnding(1);
        _isGetEnd = true;
    }
    public void CheckGameObject(GameObject input)
    {
        
        _currentSelectObject = input;
      
        
       
        inventory.CheckCanInsertObject(_currentSelectObject);
        
            _flowIndex++; 
            
          
        
        
    }


    public void tryGoLobby()
    {
        if (_isGetEnd)
        {
            GameManager.Instance.LoadScene();
        }
    }
    
  
   
}