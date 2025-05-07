using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    
    public List<GameObject> flowObjects = new List<GameObject>();
    public List<GameObject> lastDoors = new List<GameObject>();
    public TotalInventoryController inventory;
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

    public void CheckGameObject()
    {
        if (_flowIndex>=1&&_gameSwitchCount >= 4) // 아직 히든앤딩이 가능하고 꿈 현실 변환도 4번 이상하면 
        {
            //히든 앤딩
        }
        else if (_gameSwitchCount >= 4) // 히든엔딩이 안되지만 4번이상
        {
            //배드엔딩
        }
        else if (flowObjects.Count == _flowIndex + 1) // 기존 플로우를 다하면 
        {
            if (lastDoors[0] == _currentSelectObject) //꿈일때
            {
                //노멀엔딩
            }
            else
            {
                //트루엔딩
                
            }
        }
        
        
        if (flowObjects[_flowIndex] == _currentSelectObject) // 현재 플로우에딱 적합한 물체라면 
        {
            _previousObject = _currentSelectObject; //플로우 증가 
            _flowIndex++; // 플로우 증가 
            inventory.CheckCanInsertObject(_currentSelectObject);
            //스크립트 출력
            
            //아이템을 얻고  플로우 진행 
        }
        
    }
}
