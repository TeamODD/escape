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
        public bool isUsed;
        public GameObject QuitButton;
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

        public bool _isApplyButtonOn;
        public bool _isApplyDialogueDontOut;
        public SelectButtonController SelectButtonController;
        
        private int _isApplyedIdx;

        public void PlayDialogue(DialogueData data)
        {
            isUsed = true;
            _isApplyedIdx = -1;
            _isApplyButtonOn = false;
            _isApplyDialogueDontOut = false;
            
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
                _contentIndex++;
                //Data.OnCompleted.Invoke();
                if (_isApplyDialogueDontOut) //선택버튼은 필요없지만 나가면안될때
                {
                    
                    return;
                }
                else if (_isApplyButtonOn  )  //선택버튼 필요 
                {

                    return;
                }

                OnCompleted.Invoke();
              
                
               
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
            QuitButton.SetActive(false);
            _isApplyButtonOn = true;
            _isApplyedIdx = idx;
        }
        
        public void applyDialogueOn()
        {
            _isApplyDialogueDontOut=true;
        }

        public void SetDialogueStatusfalse()
        {
            isUsed = false;
        }
      
    }
}