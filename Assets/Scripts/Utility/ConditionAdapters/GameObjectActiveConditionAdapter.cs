namespace Assets.Scripts.Utility.ConditionAdapters
{
    using UnityEngine;

    public class GameObjectActiveConditionAdapter : IConditionAdapter
    {
        [SerializeField] private GameObject _target;
        public bool IsSatisfied()
        {
            return _target.activeSelf;
        }
    }
}