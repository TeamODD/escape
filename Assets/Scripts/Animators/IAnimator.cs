namespace Assets.Scripts.Animators
{
    public interface IAnimator
    {
        /// <summary>
        /// 애니메이션이 현재 재생 중인지 여부를 반환합니다.
        /// </summary>
        bool IsPlaying { get; }
        /// <summary>
        /// 애니메이션을 재생합니다.
        /// </summary>
        void PlayAnimation();
        /// <summary>
        /// 애니메이션을 중단합니다.
        /// </summary>
        void StopAnimation();
        /// <summary>
        /// 애니메이션을 즉시 완료 처리합니다.
        /// </summary>
        void CompleteAnimation();
        /// <summary>
        /// 애니메이션을 일시 정지합니다.
        /// </summary>
        void PauseAnimation();
        /// <summary>
        /// 일시 정지된 애니메이션을 재개합니다.
        /// </summary>
        void ResumeAnimation();
    }
}