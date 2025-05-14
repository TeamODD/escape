using Unity.VisualScripting;

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
        
        [field:SerializeField] public UnityEvent OnCompleted{ get; private set; }
        private int _contentIndex;

        private bool _isApplyButtonOn;
        
        private int _isApplyedIdx;
        public SelectButtonController SelectButtonController;
        public void PlayDialogue(DialogueData data)
        {
           Debug.Log("PlayDialogue");
            _isApplyButtonOn = false;
            
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
            Debug.Log(_isApplyButtonOn);
            Debug.Log(_isApplyedIdx);
            Debug.Log(_contentIndex);
            if (_isApplyButtonOn&&_isApplyedIdx==_contentIndex)//버튼키기 신청이 되있다면 또한 버튼설정된것과 일치한다묜
            {
                SelectButtonController.SwithchAllButtonStatus(true);//그때 버튼을켜라
            }
           
            if(Animator.IsPlaying)
            {
                Animator.CompleteAnimation();
                return;
            }
            if(_contentIndex==Data.Contents.Length)
            {
                Animator.CompleteAnimation();
                //Data.OnCompleted.Invoke();
                if (_isApplyButtonOn == false) 
                {
                    
                    OnCompleted.Invoke();
                }
                
                
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

        

        public void applyButtonOn(int idx)
        {
            
            _isApplyButtonOn = true;
            _isApplyedIdx = idx;
        }
        
        public void applyDialogueOn()
        {
            _isApplyButtonOn = true;
            
            
        }
        
    }
}