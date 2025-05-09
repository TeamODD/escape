namespace Assets.Scripts.Utility
{
    using UnityEngine;
    using UnityEngine.Events;

    public class Toggle : MonoBehaviour
    {
        [field:SerializeField] private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                if(value)
                {
                    OnActivated.Invoke();
                }
                else
                {
                    OnDeactivated.Invoke();
                }
            }
        }
        public void OnToggle()
        {
            IsActive = !IsActive;
        }
        [field:SerializeField] public UnityEvent OnActivated { get; private set; }
        [field:SerializeField] public UnityEvent OnDeactivated { get; private set; }
    }
}