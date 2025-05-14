using System;
using UnityEngine;
using UnityEngine.UI;

public class ZoomTarget : MonoBehaviour
{
    
    
    [SerializeField] private Sprite targetSprite;
    public ZoomImageManager manager;
    public SelectButtonController _selectButtonController;
    public Image HitImage; 
    private void Start()
    {
        
    }


    public void SwitchHitImageName(String name)
    {
        HitImage.name = name;
    }

    public void ZoomRequset() // 줌시도할때
    {
        GameManager.Instance.SwitchZoomInStatus(true);
        ClickHandler clickTarget = GetComponent<ClickHandler>();

        if (clickTarget.GetisEnableZoomStatus()) // 만약 줌인이 가능한 상태라면 
        {
            _selectButtonController.SetAnswerInt(gameObject);//자신을 보냄   
            _selectButtonController.SwithchAllButtonStatus(false); //기본적으로 버튼은 꺼져있게 설정 
            
            
            manager.Show(targetSprite);
            
        }
        
    }

    public void MakeSelectButton()
    {
        _selectButtonController.SwithchAllButtonStatus(true);
    }
    
}