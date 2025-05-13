namespace Assets.Scripts.Animators
{
    using UnityEngine;
    using DG.Tweening;

    public class ScaleAnimator : AbstractAnimator
    {
        [Tooltip("애니메이션 대상 오브젝트입니다.")]
        [SerializeField] private Transform _target;
        [Tooltip("상대 크기로 조절할지 여부를 결정합니다. 활성화하면 현재 크기를 기준으로 지정된 크기만큼 조절합니다.")]
        [SerializeField] private bool _relative = false;
        [Tooltip("변환할 크기 값입니다.")]
        [SerializeField] private Vector3 _endValue = Vector3.zero;
        [Tooltip("애니메이션의 지속 시간(초)입니다.")]
        [SerializeField] private float _duration = 0.5f;
        [Tooltip("적용할 이징(Ease) 타입입니다.")]
        [SerializeField] private Ease _ease = Ease.Linear;
        /// <summary>
        /// 크기 변환 애니메이션 시퀀스를 생성합니다.
        /// </summary>
        /// <returns>애니메이션 시퀀스</returns>
        protected override Sequence CreateAnimationSequence()
        {
            return DOTween.Sequence()
            .Append(_target.DOScale(_endValue, _duration).SetEase(_ease).SetRelative(_relative));
        }
    }
}