namespace Assets.Scripts.Animators
{
    using System;
    using UnityEngine;

    [Serializable]
    public class SequenceEntry
    {
        [field:SerializeField] public SequenceLinkType LinkType { get; private set; }
        [field:SerializeField] public ISequenceCreator Creator { get; private set; }
    }
}