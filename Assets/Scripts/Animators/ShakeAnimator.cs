namespace Assets.Scripts.Animators
{
    using UnityEngine;
    using DG.Tweening;

    public class ShakeAnimator : AbstractAnimator
    {
        [Tooltip("애니메이션 대상 오브젝트입니다.")]
        [SerializeField] private Transform _target;
        [Tooltip("애니메이션의 지속 시간(초)입니다.")]
        [SerializeField] private float _duration = 0.1f;
        [Tooltip("진동 세기입니다.")]
        [SerializeField] private float _strength = 0.1f;
        [Tooltip("초당 진동 횟수입니다.")]
        [SerializeField] private int _vibrato = 50;
        [Tooltip("진동 방향의 무작위성 정도(0~180)입니다.")]
        [SerializeField] private float _randomness = 90;
        [Tooltip("좌표 값을 정수로 강제할지 여부를 결정합니다.")]
        [SerializeField] private bool _snapping = false;
        [Tooltip("활성화 시 진동이 점점 줄어들도록 처리합니다.")]
        [SerializeField] private bool _fadeOut = true;
        [Tooltip("진동 방향의 무작위성 모드를 설정합니다.")]
        [SerializeField] private ShakeRandomnessMode _shakeRandomnessMode = ShakeRandomnessMode.Full;
        /// <summary>
        /// 진동 애니메이션 시퀀스를 생성합니다.
        /// </summary>
        /// <returns>애니메이션 시퀀스</returns>
        protected override Sequence CreateAnimationSequence()
        {
            return DOTween.Sequence()
            .Append(_target.DOShakePosition(_duration, _strength, _vibrato, _randomness, _snapping, _fadeOut, _shakeRandomnessMode));
        }
    }
}