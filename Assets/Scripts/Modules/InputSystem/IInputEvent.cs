namespace Assets.Scripts.Modules.InputSystem
{
    public interface IInputEvent<T>
    {
        T InputValue { get; }
    }
}