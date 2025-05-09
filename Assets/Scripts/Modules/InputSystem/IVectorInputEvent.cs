namespace Assets.Scripts.Modules.InputSystem
{
    using UnityEngine;
    using UnityEngine.Events;

    public interface IVectorInputEvent : IInputEvent<Vector2>
    {
        UnityEvent<Vector2> OnInputChanged { get; }
    }
}