namespace Assets.Scripts.Animators
{
    using UnityEngine;
    using DG.Tweening;

    public class FadeOutAnimator : AbstractAnimator
    {
        [Tooltip("페이드 아웃 대상 SpriteRenderer입니다.")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [Tooltip("페이드 아웃 후 최종 알파 값입니다.")]
        [SerializeField] private float _endValue = 0f;
        [Tooltip("애니메이션의 지속 시간(초)입니다.")]
        [SerializeField] private float _duration = 0.5f;
        [Tooltip("적용할 이징(Ease) 타입입니다.")]
        [SerializeField] private Ease _ease = Ease.Linear;
        [Tooltip("애니메이션 종료 후 오브젝트 비활성화 여부입니다.")]
        [SerializeField] private bool _deactivateOnComplete = true;
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
        /// 애니메이션 종료 시 SpriteRenderer의 알파 값을 최종값으로 설정하고,
        /// 필요 시 오브젝트를 비활성화합니다.
        /// </summary>
        protected override void OnComplete()
        {
            _spriteRenderer.color = new Color(_color.r, _color.g, _color.b, _endValue);
            if(_deactivateOnComplete)
            {
                gameObject.SetActive(false);
            }
        }
        /// <summary>
        /// SpriteRenderer에 페이드 아웃 애니메이션 시퀀스를 생성합니다.
        /// </summary>
        /// <returns>생성된 시퀀스</returns>
        protected override Sequence CreateSequence()
        {
            return DOTween.Sequence()
            .Append(_spriteRenderer.DOFade(_endValue, _duration))
            .SetEase(_ease);
        }
    }
}