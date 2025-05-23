namespace Assets.Scripts.SoundControl
{
    using DG.Tweening;
    using UnityEngine;

    public class SoundPlayer : MonoBehaviour
    {
        public void PlayBGM(AudioClip audioClip)
        {
            if (SoundControllerScript.Instance == null)
            {
                return;
            }
            SoundControllerScript.Instance.StartMainBgm(audioClip);
        }
        public void PlaySFX(AudioClip audioClip)
        {
            if (SoundControllerScript.Instance == null)
            {
                return;
            }
            SoundControllerScript.Instance.StartEffectBgm(audioClip);
        }
        public void StopBGM()
        {
            if (SoundControllerScript.Instance == null)
            {
                return;
            }
            AudioSource audioSource = SoundControllerScript.Instance.bgmSource;
            Sequence sequence = DOTween.Sequence();
            if (audioSource.isPlaying)
            {
                sequence.Append(audioSource.DOFade(0, 1f).SetEase(Ease.InQuad));
                sequence.AppendCallback(() => audioSource.Stop());
            }
        }
    }
}