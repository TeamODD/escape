namespace Assets.Scripts.Escape.Dialogue
{
    using UnityEngine;
    using UnityEngine.Events;
    using Sirenix.OdinInspector;
    using TMPro;
    using Animators;

    public class DialogueController : SerializedMonoBehaviour
    {
        // public static DialogueController Instance { get; private set; }
        // private void Awake()
        // {
        //     if (Instance != null && Instance != this)
        //     {
        //         Destroy(gameObject);
        //         return;
        //     }
        //     Instance = this;
        // }
        [field:SerializeField] private TMP_Text _text;
        [field:SerializeField] private TextFadeAnimator _animator;
        [field:SerializeField] public UnityEvent OnPlayDialogue { get; private set; }
        [field:SerializeField] public UnityEvent OnNextDialogue { get; private set; }
        [field:SerializeField] public UnityEvent OnDialogueCompleted { get; private set; }
        private DialogueData _data;
        private int _contentIndex;
        public void PlayDialogue(DialogueData data)
        {
            _data = data;
            _contentIndex = 0;
            _text.text = _data.Contents[_contentIndex++];
            OnPlayDialogue.Invoke();
        }
        public void NextDialogue()
        {
            if(_animator.IsPlaying)
            {
                _animator.CompleteAnimation();
                return;
            }
            if(_contentIndex==_data.Contents.Length)
            {
                _contentIndex++;
                _animator.CompleteAnimation();
                OnDialogueCompleted.Invoke();
                _data.OnCompleted.Invoke();
                return;
            }
            else if(_contentIndex>_data.Contents.Length)
            {
                return;
            }
            _text.text = _data.Contents[_contentIndex++];
            OnNextDialogue.Invoke();
            _animator.PlayAnimation();
        }
    }
}