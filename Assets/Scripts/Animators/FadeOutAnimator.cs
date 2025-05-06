namespace Assets.Scripts.Animators
{
    using UnityEngine;
    using DG.Tweening;
    using Animators.FadableAdapters;

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
        [Tooltip("애니메이션 종료 후 오브젝트 비활성화 여부입니다.")]
        [SerializeField] private bool _deactivateOnComplete = true;
        /// <summary>
        /// 애니메이션 종료 시 대상을 최종값으로 설정합니다.
        /// </summary>
        protected override void OnComplete()
        {
            _fadable.Value = _endValue;
            if(_deactivateOnComplete)
            {
                gameObject.SetActive(false);
            }
        }
        /// <summary>
        /// 대상에 페이드 아웃 애니메이션 시퀀스를 생성합니다.
        /// </summary>
        /// <returns>생성 시퀀스</returns>
        protected override Sequence CreateSequence()
        {
            return DOTween.Sequence()
            .Append(DOTween.To(()=>_fadable.Value, x => _fadable.Value = x, _endValue, _duration).SetEase(_ease));
        }
    }
}