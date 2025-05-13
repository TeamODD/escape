namespace Assets.Scripts.Animators
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using DG.Tweening;
    using Sirenix.OdinInspector;
    using TMPro;

    public class TextFadeAnimator : SerializedMonoBehaviour, IAnimator
    {
        /// <summary>
        /// 현재 시퀀스의 재생 여부를 반환합니다.
        /// </summary>
        public bool IsPlaying => _animationCoroutine != null || _runningTweens.Count > 0;
        /// <summary>
        /// 애니메이션 시작 시 발생하는 이벤트입니다. 
        /// 인스펙터 또는 코드에서 리스너를 등록하여 시작 시 호출할 동작을 연결할 수 있습니다.
        /// </summary>
        [field:SerializeField] public UnityEvent OnStartEvent { get; protected set; }
        /// <summary>
        /// 애니메이션 완료 시 발생하는 이벤트입니다. 
        /// 인스펙터 또는 코드에서 리스너를 등록하여 완료 시 호출할 동작을 연결할 수 있습니다.
        /// </summary>
        [field:SerializeField] public UnityEvent OnCompleteEvent { get; protected set; }
        /// <summary>
        /// 애니메이션 중단 시 발생하는 이벤트입니다. 
        /// /// 인스펙터 또는 코드에서 리스너를 등록하여 중단 시 호출할 동작을 연결할 수 있습니다.
        /// </summary>
        [field:SerializeField] public UnityEvent OnKillEvent { get; protected set; }
        [Tooltip("애니메이션 대상 텍스트입니다.")]
        [SerializeField] private TMP_Text Text;
        [Tooltip("초당 몇 개의 문자를 출력할지 설정합니다.")]
        [SerializeField] private float _charactersPerSecond = 30f;
        [Tooltip("페이드 최종값입니다.")]
        [SerializeField] private float _endAlpha = 1f;
        [Tooltip("문자당 애니메이션의 지속 시간(초)입니다.")]
        [SerializeField] private float _animationDurationPerCharacter = 1f;
        [Tooltip("적용할 이징(Ease) 타입입니다.")]
        [SerializeField] private Ease _ease = Ease.Linear;
        /// <summary>
        /// 현재 진행 중인 애니메이션 코루틴입니다.
        /// </summary>
        private Coroutine _animationCoroutine;
        /// <summary>
        /// 출력된 글자 인덱스를 저장합니다.
        /// </summary>
        private readonly HashSet<int> _processedIndices = new();
        /// <summary>
        /// 현재 재생 중인 애니메이션 트윈을 저장합니다.
        /// </summary>
        private readonly HashSet<Tween> _runningTweens = new();
        /// <summary>
        /// 출력 경과 시간입니다.
        /// </summary>
        private float _elapsedTime = 0f;
        /// <summary>
        /// 마지막으로 출력된 글자의 인덱스입니다.
        /// </summary>
        private int _lastIndex = -1;
        /// <summary>
        /// 애니메이션을 재생합니다.
        /// </summary>
        public void PlayAnimation()
        {
            if(IsPlaying)
            {
                return;
            }
            _processedIndices.Clear();

            _elapsedTime = 0f;
            _lastIndex = -1;
            Text.ForceMeshUpdate();

            OnStartEvent.Invoke();

            _animationCoroutine = StartCoroutine(StartFadeText());
        }
        /// <summary>
        /// 애니메이션을 중단합니다.
        /// </summary>
        public void StopAnimation()
        {
            if(IsPlaying)
            {
                StopCoroutine(_animationCoroutine);
                _animationCoroutine = null;
            }

            foreach(Tween tween in _runningTweens)
            {
                tween.Kill();
            }

            _runningTweens.Clear();
            _processedIndices.Clear();

            OnKillEvent.Invoke();
        }
        /// <summary>
        /// 애니메이션을 즉시 완료 처리합니다.
        /// </summary>
        public void CompleteAnimation()
        {
            if(!IsPlaying)
            {
                return;
            }
            
            if(_animationCoroutine != null)
            {
                StopCoroutine(_animationCoroutine);
                _animationCoroutine = null;
            }

            foreach(Tween tween in _runningTweens)
            {
                tween.Kill();
            }

            for(int i=0;i<Text.textInfo.characterCount;i++)
            {
                int matIndex = Text.textInfo.characterInfo[i].materialReferenceIndex;
                int vertIndex = Text.textInfo.characterInfo[i].vertexIndex;
                Color32[] colors = Text.textInfo.meshInfo[matIndex].colors32;
                for(int j=0;j<4;j++)
                {
                    colors[vertIndex + j].a = (byte)(_endAlpha * 255);
                }
            }
            Text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

            _runningTweens.Clear();
            _processedIndices.Clear();

            OnCompleteEvent.Invoke();
            OnKillEvent.Invoke();
        }
        /// <summary>
        /// 애니메이션을 일시 정지합니다.
        /// </summary>
        public void PauseAnimation()
        {
            if(_runningTweens.Count <= 0)
            {
                return;
            }
            
            if(_animationCoroutine != null)
            {
                StopCoroutine(_animationCoroutine);
                _animationCoroutine = null;
            }

            foreach(Tween tween in _runningTweens)
            {
                tween.Pause();
            }
        }
        /// <summary>
        /// 일시 정지된 애니메이션을 재개합니다.
        /// </summary>
        public void ResumeAnimation()
        {
            if(IsPlaying)
            {
                return;
            }

            _animationCoroutine = StartCoroutine(StartFadeText());

            foreach(Tween tween in _runningTweens)
            {
                tween.Play();
            }
        }
        /// <summary>
        /// 각 글자에 대해 일정 속도로 순차적으로 페이드 애니메이션을 적용합니다.
        /// </summary>
        private IEnumerator StartFadeText()
        {
            while(_elapsedTime<Text.textInfo.characterCount)
            {
                yield return null;

                _elapsedTime += Time.deltaTime * _charactersPerSecond;
                int maxIndex = Mathf.FloorToInt(_elapsedTime);
                maxIndex = Mathf.Min(maxIndex, Text.textInfo.characterCount-1);
                for (int i = _lastIndex + 1; i <= maxIndex; i++)
                {
                    if (!_processedIndices.Contains(i))
                    {
                        FadeCharacters(i);
                        _processedIndices.Add(i);
                    }
                }
                _lastIndex = maxIndex;
            }

            _animationCoroutine = null;
        }
        /// <summary>
        /// 지정된 글자 인덱스에 대해 페이드 애니메이션을 실행합니다.
        /// </summary>
        /// <param name="index">글자 인덱스</param>
        private void FadeCharacters(int index)
        {
            TMP_TextInfo textInfo = Text.textInfo;

            int matIndex = textInfo.characterInfo[index].materialReferenceIndex;
            int vertIndex = textInfo.characterInfo[index].vertexIndex;
            Color32[] colors = textInfo.meshInfo[matIndex].colors32;

            Tween tween = DOTween.To(() => colors[vertIndex].a/255f, a =>
            {
                    byte byteAlpha = (byte)(a * 255);
                    for (int i = 0; i < 4; i++)
                    {
                        colors[vertIndex + i].a = byteAlpha;
                    }

                    Text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            }, 1f, _animationDurationPerCharacter).SetEase(_ease);
            tween
            .OnStart(()=>
            {
                _runningTweens.Add(tween);
            })
            .OnComplete(()=>
            {
                _runningTweens.Remove(tween);

                if (index == Text.textInfo.characterCount-1)
                {
                    _processedIndices.Clear();

                    OnCompleteEvent.Invoke();
                    OnKillEvent.Invoke();
                }
            })
            .Play();
        }
    }
}