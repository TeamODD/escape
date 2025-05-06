namespace Assets.Scripts.Animators
{
    using UnityEngine;
    using DG.Tweening;

    public class FadeInAnimator : AbstractAnimator
    {
        [Tooltip("페이드 인 대상 SpriteRenderer입니다.")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [Tooltip("페이드 인 후 최종 알파 값입니다.")]
        [SerializeField] private float _endValue = 1f;
        [Tooltip("애니메이션의 지속 시간(초)입니다.")]
        [SerializeField] private float _duration = 0.5f;
        [Tooltip("적용할 이징(Ease) 타입입니다.")]
        [SerializeField] private Ease _ease = Ease.Linear;
        /// <summary>
        /// SpriteRenderer의 초기 색상 값을 저장합니다.
        /// </summary>
        private Color _color;
        /// <summary>
        /// Awake에서 SpriteRenderer의 초기 색상을 캐싱합니다.
        /// </summary>
        private void Awake()
        {
            _color = _spriteRenderer.color;
        }
        /// <summary>
        /// 애니메이션 종료 시 SpriteRenderer의 알파 값을 최종값으로 설정합니다.
        /// </summary>
        protected override void OnComplete()
        {
            _spriteRenderer.color = new Color(_color.r, _color.g, _color.b, _endValue);
        }
        /// <summary>
        /// SpriteRenderer에 페이드 인 애니메이션 시퀀스를 생성합니다.
        /// 애니메이션 시작 전 오브젝트를 활성화합니다.
        /// </summary>
        /// <returns>생성 시퀀스</returns>
        protected override Sequence CreateSequence()
        {
            gameObject.SetActive(true);

            return DOTween.Sequence()
            .Append(_spriteRenderer.DOFade(_endValue, _duration))
            .SetEase(_ease);
        }
    }
}