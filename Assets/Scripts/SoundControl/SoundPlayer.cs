namespace Assets.Scripts.SoundControl
{
    using UnityEngine;
    
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip;
        public void PlayBGM()
        {
            SoundControllerScript.Instance.StartMainBgm(_audioClip);
        }
        public void PlaySFX()
        {
            SoundControllerScript.Instance.StartEffectBgm(_audioClip);
        }
    }
}