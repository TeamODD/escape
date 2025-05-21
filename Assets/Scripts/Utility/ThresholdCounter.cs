namespace Assets.Scripts.Utility
{
    using UnityEngine;
    using UnityEngine.Events;

    public class ThresholdCounter : MonoBehaviour
    {
        [field:SerializeField] public UnityEvent OnThresholdReached { get; private set; }
        [SerializeField] private int _threshold;
        [SerializeField] private bool _resetOnThresholdReached;
        [SerializeField] private int _count = 0;

        public void Increment()
        {
            if (++_count >= _threshold)
            {
                OnThresholdReached.Invoke();
                if (_resetOnThresholdReached)
                {
                    _count = 0;
                }
            }
        }

        public void ResetCounter()
        {
            _count = 0;
        }
    }
}