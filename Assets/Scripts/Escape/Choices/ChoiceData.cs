namespace Assets.Scripts.Escape.Choices
{
    using UnityEngine;
    using UnityEngine.Events;
    using Sirenix.OdinInspector;

    public class ChoiceData : SerializedMonoBehaviour
    {
        [field: SerializeField] public UnityEvent OnCofirmed { get; private set; }
        [field: SerializeField] public string ConfirmChoice { get; private set; }
        [field: SerializeField] public string CancelChoice { get; private set; }
    }
}
