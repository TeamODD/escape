namespace Assets.Scripts.Dialogue
{
    using UnityEngine;
    using UnityEngine.Events;

    public class DialogueData
    {
        [field:SerializeField] public CompleteType CompleteType { get; private set; }
        [field:SerializeField] public string[] Contents { get; private set; }
        [field:SerializeField] public UnityEvent OnCompleted { get; private set; }
    }
}