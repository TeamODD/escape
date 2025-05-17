namespace Assets.Scripts.Escape.Dialogue
{
    using UnityEngine;
    using UnityEngine.Events;
    using Sirenix.OdinInspector;

    public class DialogueData : SerializedMonoBehaviour
    {
        [field:SerializeField] public UnityEvent OnCompleted { get; private set; }
        [field:SerializeField] public string[] Contents { get; private set; }
    }
}