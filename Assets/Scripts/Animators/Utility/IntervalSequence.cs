namespace Assets.Scripts.Animators.Utility
{
    using UnityEngine;
    using DG.Tweening;

    public class IntervalSequence : ISequenceCreator
    {
        [field:SerializeField] public float Interval { get; private set; }
        public Sequence CreateSequence()
        {
            return DOTween.Sequence().AppendInterval(Interval);
        }
    }
}