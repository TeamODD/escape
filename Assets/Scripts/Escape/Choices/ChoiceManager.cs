namespace Assets.Scripts.Escape.Choices
{
    using UnityEngine;
    using Sirenix.OdinInspector;
    using TMPro;
    using UnityEngine.Events;

    public class ChoiceManager : SerializedMonoBehaviour
    {
        public static ChoiceManager Instance { get; private set; }
        [field:SerializeField] public UnityEvent OnDataApplied { get; private set; }
        [field:SerializeField] private TMP_Text _comfirmChoiceText;
        [field:SerializeField] private TMP_Text _cancleChoiceText;
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
        public void Confirm()
        {
            _choiceData.OnCofirmed.Invoke();
        }
    }        
}
