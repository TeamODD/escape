using System;
using Assets.Scripts.Dialogue;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public FlowController FlowController;
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
    private bool _isLightOn;
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