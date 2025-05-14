namespace Assets.Scripts.Dialogue
{
    using UnityEngine;
    using UnityEngine.Events;

    [CreateAssetMenu(menuName = "Dialogue/DialogueData")]
    public class DialogueData :ScriptableObject
    {
        [field:SerializeField] public CompleteType CompleteType { get; private set; }
        [field:SerializeField] public string[] Contents { get; private set; }
        [field:SerializeField] public UnityEvent OnCompleted { get; private set; }
    }
}