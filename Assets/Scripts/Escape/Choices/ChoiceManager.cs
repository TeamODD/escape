namespace Assets.Scripts.Escape.Choices
{
    using UnityEngine;
    using Sirenix.OdinInspector;
    using TMPro;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class ChoiceManager : SerializedMonoBehaviour, ISceneStateHandler
    {
        public static ChoiceManager Instance { get; private set; }
        [field: SerializeField] public UnityEvent OnDataApplied { get; private set; }
        [field: SerializeField] private TMP_Text _comfirmChoiceText;
        [field: SerializeField] private TMP_Text _cancleChoiceText;

        [field: SerializeField] private Image _comfirmImage;
        [field: SerializeField] private Image _cancleImage;
        [field: SerializeField] private Sprite _realitySprite;
        [field: SerializeField] private Sprite _dreamSprite;

        private ChoiceData _choiceData;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            Instance = this;
        }
        public void ApplyChoiceData(ChoiceData data)
        {
            _choiceData = data;
            _comfirmChoiceText.text = data.ConfirmChoice;
            _cancleChoiceText.text = data.CancelChoice;
            OnDataApplied.Invoke();
        }
        public void OnConfirm()
        {
            _choiceData.OnCofirmed.Invoke();
        }
        public void OnCancle()
        {
            _choiceData.OnCancled.Invoke();
        }

        private SceneState _state;
        public SceneState State
        {
            get => _state;
            set
            {
                _state = value;
                if (State == SceneState.Reality)
                {
                    _comfirmImage.sprite = _realitySprite;
                    _cancleImage.sprite = _realitySprite;
                }
                else
                {
                    _comfirmImage.sprite = _dreamSprite;
                    _cancleImage.sprite = _dreamSprite;
                }
            }
        }
        public void InitializeState()
        {
            State = SceneState.Reality;
        }
    }        
}
