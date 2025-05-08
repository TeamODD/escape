namespace Assets.Scripts.Animators
{
    using DG.Tweening;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class AbstractAnimator : SerializedMonoBehaviour, IAnimator
    {
        protected Sequence Sequence { get; private set; }
        public bool IsPlaying => Sequence != null && Sequence.IsPlaying();
        /// <summary>
        /// 시퀀스를 생성합니다. ResetAnimation 메서드에서 호출됩니다.
        /// </summary>
        protected abstract Sequence CreateSequence();
        /// <summary>
        /// 필요에 따라 오버라이드할 수 있는 OnStart 콜백 메서드입니다.
        /// </summary>
        protected virtual void OnStart() { }
        /// <summary>
        /// 애니메이션 시작 시 발생하는 이벤트입니다. 
        /// 인스펙터 또는 코드에서 리스너를 등록하여 완료 시 호출할 동작을 연결할 수 있습니다.
        /// </summary>
        [field:SerializeField] public UnityEvent OnStartEvent { get; protected set; }
        /// <summary>
        /// 필요에 따라 오버라이드할 수 있는 OnComplete 콜백 메서드입니다.
        /// </summary>
        protected virtual void OnComplete() { }
        /// <summary>
        /// 애니메이션 완료 시 발생하는 이벤트입니다. 
        /// 인스펙터 또는 코드에서 리스너를 등록하여 완료 시 호출할 동작을 연결할 수 있습니다.
        /// </summary>
        [field:SerializeField] public UnityEvent OnCompleteEvent { get; protected set; }
        /// <summary>
        /// 필요에 따라 오버라이드할 수 있는 OnKill 콜백 메서드입니다.
        /// </summary>
        protected virtual void OnKill() { }
        /// <summary>
        /// 애니메이션 중단 시 발생하는 이벤트입니다. 
        /// /// 인스펙터 또는 코드에서 리스너를 등록하여 완료 시 호출할 동작을 연결할 수 있습니다.
        /// </summary>
        [field:SerializeField] public UnityEvent OnKillEvent { get; protected set; }
        /// <summary>
        /// 애니메이션을 초기화합니다. 재생 시 자동 호출됩니다.
        /// </summary>
        protected void ResetAnimation()
        {
            StopAnimation();
            Sequence = CreateSequence()
            .OnStart(()=>
            {
                OnStart();
                OnStartEvent.Invoke();
            })
            .OnComplete(()=>
            {
                OnComplete();
                OnCompleteEvent.Invoke();
            })
            .OnKill(()=>
            {
                OnKill();
                OnKillEvent.Invoke();
                Sequence = null;
            });
        }
        /// <summary>
        /// 애니메이션을 재생합니다.
        /// </summary>
        public void PlayAnimation()
        {
            if(IsPlaying)
            {
                return;
            }
            ResetAnimation();
            Sequence.Play();
        }
        /// <summary>
        /// 애니메이션을 중단합니다.
        /// </summary>
        public void StopAnimation()
        {
            if(Sequence == null)
            {
                return;
            }
            Sequence.Kill();
        }
        /// <summary>
        /// 애니메이션을 즉시 완료 처리합니다.
        /// </summary>
        public void CompleteAnimation()
        {
            if(Sequence == null || !IsPlaying)
            {
                return;
            }
            Sequence.Complete();
        }
        /// <summary>
        /// 애니메이션을 일시 정지합니다.
        /// </summary>
        public void PauseAnimation()
        {
            if(Sequence == null || !IsPlaying)
            {
                return;
            }
            Sequence.Pause();
        }
        /// <summary>
        /// 일시 정지된 애니메이션을 재개합니다.
        /// </summary>
        public void ResumeAnimation()
        {
            if(Sequence == null)
            {
                return;
            }
            Sequence.Play();
        }
    }
}