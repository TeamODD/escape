namespace Assets.Scripts.Animators
{
    using System.Collections.Generic;
    using DG.Tweening;
    using Sirenix.Serialization;

    public class CompositeAnimator : AbstractAnimator
    {
        [OdinSerialize] public List<SequenceEntry> SequenceCreators { get; private set; }
        protected override Sequence CreateAnimationSequence()
        {
            Sequence sequence = DOTween.Sequence();
            foreach(SequenceEntry entry in SequenceCreators)
            {
                switch(entry.LinkType)
                {
                    case SequenceLinkType.Append:
                        sequence.Append(entry.Creator.CreateSequence());
                        break;
                    case SequenceLinkType.Join:
                        sequence.Join(entry.Creator.CreateSequence());
                        break;
                }
            }
            return sequence;
        }
    }
}