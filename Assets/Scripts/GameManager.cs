using System;
using System.Collections.Generic;
using Assets.Scripts.Dialogue;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

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
    private SoundControllerScript _soundControllerScript;
    private bool _isZoomIn;
    private bool _isFirstChange;
    private bool _isLightOn;
    private bool _isWindowEmpty;
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
        
        _dreamObjects.SetActive(IsInDream);
        _realityObjects.SetActive(!IsInDream);
        _soundControllerScript=SoundControllerScript.Instance;
        _clickSFX=Resources.Load<AudioClip>("SFX/CLICK");
    }

    private void Update()
    {
        
    }

    public void SwitchWorld()
    {
        
        if (!_isZoomIn&&!DialogueController.Instance.isUsed&&!isInvOpen)//줌인이 되어있지 않다면
        {
            OnFade.Invoke();
           

            
        }
        
    }

    public void ApplySwitch()
    {
        FlowController.CheckSwitch();
        IsInDream = !IsInDream;
        _dreamObjects.SetActive(IsInDream);
        _realityObjects.SetActive(!IsInDream);
        totalInventoryController.AllInventorySwitchStatus(IsInDream);
        _switchMusic();
        if (isLightOn)
        {
            DialogueController.Instance.PlayDialogue(lightOnDialogue);
            lighControlScript.LightOn();
            isLightOn = false;
            _isWindowEmpty = true;
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
        }
        else//현실에서 
        {
            if (_isWindowEmpty) //창있을때
            {
                lights[0].intensity = 0.4f;
                lights[1].intensity = 1;
            }
            else//창없을때
            {
                lights[0].intensity = 0.8f;
                lights[1].intensity = 0f;
            }
            
        }
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
        _soundControllerScript.StartMainBgm(MainAudio);
    }

    public void SwitchZoomInStatus(bool input)
    {
        
        _isZoomIn = input;
    }
   
 
}