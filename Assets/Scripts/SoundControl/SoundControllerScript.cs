using UnityEngine;
using UnityEngine.Audio;

public class SoundControllerScript : MonoBehaviour
{

    public AudioSource bgmSource; // 메인 오디오 출력되는 audiosource
    public AudioSource effectSource; // 이펙트들이 출력되는 audiosource
    public float volume = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartMainBgm(AudioClip inputAudio ) // 메인 bgm 출력 시 
    {
        bgmSource.clip = inputAudio;
        bgmSource.Play();
    }

    public void StartEffectBgm(AudioClip inputAudio) //이펙트 소리 내야할 때 해당 상호작용을 일으키는 스크립트에서 원하는 소리를 집어넣은후 호출 
    {
        effectSource.clip= inputAudio;
        effectSource.Play();
    }
    

    public void VolumeSetting(float volume) //설정에서 소리변경시 모든 사운드가 설정되도록
    {
        bgmSource.volume = volume;
        effectSource.volume = volume;
    }
    
    
    public static SoundControllerScript Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


}