namespace Assets.Scripts.Dialogue
{
    using UnityEngine;
    using UnityEngine.Events;
    using Sirenix.OdinInspector;
    using TMPro;
    using Animators;

    public class DialogueController : SerializedMonoBehaviour
    {
        public static DialogueController Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        [field:SerializeField] public TMP_Text Text { get; private set; }
        [field:SerializeField] public TextFadeAnimator Animator { get; private set; }
        [field:SerializeField] public DialogueData Data { get; private set; }
        [field:SerializeField] public UnityEvent OnPlayDialogue { get; private set; }
        [field:SerializeField] public UnityEvent OnNextDialogue { get; private set; }
        private int _contentIndex;
        public void PlayDialogue(DialogueData data)
        {
            Data = data;
            _contentIndex = 0;
            Text.text = Data.Contents[_contentIndex++];
            Animator.PlayAnimation();
            OnPlayDialogue.Invoke();
        }
        public void PlayDialogue()
        {
            _contentIndex = 0;
            Text.text = Data.Contents[_contentIndex++];
            Animator.PlayAnimation();
            OnPlayDialogue.Invoke();
        }
        public void NextDialogue()
        {
            if(Animator.IsPlaying)
            {
                Animator.CompleteAnimation();
                return;
            }
            if(_contentIndex==Data.Contents.Length)
            {
                Animator.CompleteAnimation();
                Data.OnCompleted.Invoke();
                _contentIndex++;
                return;
            }
            else if(_contentIndex>Data.Contents.Length)
            {
                return;
            }
            Text.text = Data.Contents[_contentIndex++];
            Animator.PlayAnimation();
            OnNextDialogue.Invoke();
        }
    }
}