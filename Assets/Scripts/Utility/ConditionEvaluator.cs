namespace Assets.Scripts.Utility
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using Sirenix.OdinInspector;
    using ConditionAdapters;

    public class ConditionEvaluator : SerializedMonoBehaviour
    {
        [field: SerializeField] public UnityEvent OnAllConditionsMet { get; private set; }
        [SerializeField] private List<IConditionAdapter> _conditions;

        public void TryInvoke()
        {
            foreach (IConditionAdapter condition in _conditions)
            {
                if (condition == null || !condition.IsSatisfied())
                {
                    return;
                }
            }
            OnAllConditionsMet.Invoke();
        }
    }
}