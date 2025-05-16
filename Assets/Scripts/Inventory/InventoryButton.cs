using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InventoryButton : MonoBehaviour
{
    public Image buttonimage;
    public AudioClip invOpenSFX;
    public GameObject targetInventory; // 펼쳐질 인벤토리 대상 
    public float buttonHeight;
    
    private bool _isActive; // 현재 인벤토리가 펼쳐져 있는지 닫혀져 있는지 확인 
    private RectTransform _inventoryRt; // 사용될 인벤토리 변수 
    private RectTransform _selfRt; // 사용될 자신의 Rt변수
    private Coroutine _animCoroutine; // 코루틴 애니메이션변수

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inventoryRt = targetInventory.GetComponent<RectTransform>();  //RT 정보 가져오기 
        _selfRt = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 왼쪽 클릭 감지
        {
            if (!IsPointerOverUI()&&_isActive)
            {
                SwithchInventoryStatus();
            }
        }
    }
    public void SwithchInventoryStatus()
    {
        
        _isActive = !_isActive; // 상태변경 
        SoundControllerScript.Instance.StartEffectBgm(invOpenSFX);
       
        if (_isActive)
        {
            buttonimage.color = new Color(0, 0, 0, 0);
            
            GameManager.Instance.isInvOpen = true;
        }
        else
        {
           
            GameManager.Instance.isInvOpen = false;
        }
        if (_animCoroutine != null) //이미 애니메이션이 실행중일때 
            StopCoroutine(_animCoroutine);

        _animCoroutine = StartCoroutine(AnimateUI(_isActive)); // 현재 상태에 따른 애니메이션 실행 
    }

    IEnumerator AnimateUI(bool status)
    {
        float duration = 0.3f; // 애니메이션 지속 시간
        float time = 0f;

        float startBottom = _inventoryRt.offsetMin.y; //인벤토리가 보여지는 부분을 조정 
        float targetBottom = status ? 0f : buttonHeight; // 현재 상태에 따라 어디까지 보여질건지 

        float startPosY = _selfRt.anchoredPosition.y; // 현재 버튼의 위치를 조정 
        float targetPosY = status ? -buttonHeight : 0f; // 현재 버튼의 위치를 어디에 둘것인가 

        while (time < duration) // 애니메이션 실행 
        {
            time += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, time / duration);

            // bottom 애니메이션
            Vector2 offset = _inventoryRt.offsetMin; //현재 Bottom값를 받아와서 
            offset.y = Mathf.Lerp(startBottom, targetBottom, t); //위치설정 
            _inventoryRt.offsetMin = offset; // 설정된 위치를 적용 

            // 버튼 Y 위치 애니메이션
            Vector2 pos = _selfRt.anchoredPosition; // 현재 좌표값받아와서 
            pos.y = Mathf.Lerp(startPosY, targetPosY, t); //Y위치설정 
            _selfRt.anchoredPosition = pos; // 적용

            yield return null;
        }
        //최종 적용
        Vector2 finalOffset = _inventoryRt.offsetMin;
        finalOffset.y = targetBottom;
        _inventoryRt.offsetMin = finalOffset;

        Vector2 finalPos = _selfRt.anchoredPosition;
        finalPos.y = targetPosY;
        _selfRt.anchoredPosition = finalPos;

        if (!_isActive)
        {
            buttonimage.color = new Color(255, 255, 255, 255);
        }
        
    }
    
    private bool IsPointerOverUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        var raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);
        
        
        return raycastResults.Count > 0;
    }

}
