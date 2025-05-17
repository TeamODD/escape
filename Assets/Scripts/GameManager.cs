using System;
using System.Collections.Generic;
using Assets.Scripts.Dialogue;
using Assets.Scripts.UI.Options;
using Assets.Scripts.Utility.Scene;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Light2D> lights;
    public FlowController FlowController;
    public DialogueData firstchange;
    public DialogueData lightOnDialogue; 
    public bool isInvOpen;
    public LighControlScript lighControlScript;
    public AudioClip dreamBgm;
    public AudioClip realityBgm;
    public bool isLightOn = false;
    public static GameManager Instance{get; private set;}
    public TotalInventoryController totalInventoryController;
    private AudioClip _clickSFX;
    public GameObject Inventorycanvas;
    private bool _isZoomIn;
    private bool _isFirstChange;
    private bool _isLightOn;
    public bool _isWindowEmpty;
    [SerializeField] private GameObject _dreamObjects;
    [SerializeField] private GameObject _realityObjects;
   
    [field:SerializeField] public UnityEvent OnFade { get; private set; }
    public bool IsInDream { get; private set; } = false;

    private void Awake()
    {
        // 싱글톤 패턴
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        CursorManager.Instance.ChangeCursor(IsInDream);
        _dreamObjects.SetActive(IsInDream);
        _realityObjects.SetActive(!IsInDream);
        
        _clickSFX=Resources.Load<AudioClip>("SFX/CLICK");
    }

    private void Update()
    {
        
    }

    public void SwitchWorld()
    {
       
        //&&!isInvOpen
        if (!_isZoomIn&&!DialogueController.Instance.isUsed)//줌인이 되어있지 않다면
        {
            OnFade.Invoke();
        }
    }

    public void ApplySwitch()
    {
        //OptionManager.Instance.ChangeSprites();
        FlowController.CheckSwitch();
        IsInDream = !IsInDream;
        CursorManager.Instance.ChangeCursor(IsInDream);
        _dreamObjects.SetActive(IsInDream);
        _realityObjects.SetActive(!IsInDream);
        totalInventoryController.AllInventorySwitchStatus(IsInDream);
        _switchMusic();
        if (isLightOn)
        {
            DialogueController.Instance.PlayDialogue(lightOnDialogue);
            lighControlScript.LightOn();
            isLightOn = false;
          
            setLight();
        }

        if (!_isFirstChange)
        {
            _isFirstChange = true;
            DialogueController.Instance.PlayDialogue(firstchange);
        }

        if (IsInDream) //꿈으로 간다면
        {
            lights[0].intensity = 1;
            lights[1].intensity = 0;
        }else//현실에서 
        {
            if (_isWindowEmpty) //창없을때
            {
               
                lights[0].intensity = 0.8f;
                lights[1].intensity = 0;
            }
            else
            {
               
                lights[0].intensity =  0.4f;
                lights[1].intensity = 1f; //마우스 끄기 
            }
            
        }
      
    }

    public void setLight()
    {
       
        _isWindowEmpty = true;
        lights[0].intensity = 5.0f;
        lights[1].intensity = 0f;
    }
    
    private void _switchMusic()
    {
        AudioClip MainAudio;
        if (IsInDream)
        {
            MainAudio = dreamBgm;
        }
        else
        {
            MainAudio = realityBgm;
        }
        SoundControllerScript.Instance.StartMainBgm(MainAudio);
        
    }

    public void SwitchZoomInStatus(bool input)
    {
        
        _isZoomIn = input;
    }
   
    public void LoadScene()
    {
        
        
        SceneManager.LoadScene(0);
    }
 
}