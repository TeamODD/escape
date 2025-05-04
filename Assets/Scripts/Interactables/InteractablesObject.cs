namespace Assets.Scripts.Interactables
{
    using Sirenix.OdinInspector;

    public abstract class InteractablesObject : SerializedMonoBehaviour, IInteractable
    {
        public string Description;
        public string[] Choices;
        public IInteractable _linkedInteractableObject;
        public abstract void OnInteractInReality();
        public abstract void OnInteractInDream();
    }
}