namespace Assets.Scripts.Animators
{
    using UnityEngine;
    using DG.Tweening;
    using FadableAdapters;

    public class FadeOutAnimator : AbstractAnimator
    {
        [Tooltip("페이드 아웃 대상입니다.")]
        [SerializeField] private IFadableAdapter _fadable;
        [Tooltip("페이드 아웃 후 최종 값입니다.")]
        [SerializeField] private float _endValue = 0f;
        [Tooltip("애니메이션의 지속 시간(초)입니다.")]
        [SerializeField] private float _duration = 0.5f;
        [Tooltip("적용할 이징(Ease) 타입입니다.")]
        [SerializeField] private Ease _ease = Ease.Linear;
        /// <summary>
        /// 대상에 페이드 아웃 애니메이션 시퀀스를 생성합니다.
        /// </summary>
        /// <returns>애니메이션 시퀀스</returns>
        protected override Sequence CreateAnimationSequence()
        {
            return DOTween.Sequence()
            .Append(DOTween.To(()=>_fadable.Value, x => _fadable.Value = x, _endValue, _duration).SetEase(_ease));
        }
    }
}