namespace Assets.Scripts.Animators
{
    using UnityEngine;
    using DG.Tweening;
    using Animators.FadableAdapters;

    public class FadeInAnimator : AbstractAnimator
    {
        [Tooltip("페이드 인 대상입니다.")]
        [SerializeField] private IFadableAdapter _fadable;
        [Tooltip("페이드 인 후 최종 값입니다.")]
        [SerializeField] private float _endValue = 1f;
        [Tooltip("애니메이션의 지속 시간(초)입니다.")]
        [SerializeField] private float _duration = 0.5f;
        [Tooltip("적용할 이징(Ease) 타입입니다.")]
        [SerializeField] private Ease _ease = Ease.Linear;
        /// <summary>
        /// 애니메이션 종료 시 대상을 최종값으로 설정합니다.
        /// </summary>
        protected override void OnComplete()
        {
            _fadable.Value = _endValue;
        }
        /// <summary>
        /// 대상에 페이드 인 애니메이션 시퀀스를 생성합니다.
        /// 애니메이션 시작 전 오브젝트를 활성화합니다.
        /// </summary>
        /// <returns>생성 시퀀스</returns>
        protected override Sequence CreateSequence()
        {
            gameObject.SetActive(true);

            return DOTween.Sequence()
            .Append(DOTween.To(()=>_fadable.Value, x => _fadable.Value = x, _endValue, _duration).SetEase(_ease));
        }
    }
}