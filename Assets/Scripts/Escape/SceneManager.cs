namespace Assets.Scripts.Escape
{
    using UnityEngine;
    using Sirenix.OdinInspector;
    using System.Collections.Generic;

    public class SceneManager : SerializedMonoBehaviour, ISceneStateHandler
    {
        [field: SerializeField] public List<ISceneStateHandler> SceneStateHandlers { get; private set; }
        [field: SerializeField] private SceneState _state;
        [field: SerializeField] private GameObject _realityObejcts;
        [field: SerializeField] private GameObject _dreamObejcts;
        public SceneState State
        {
            get => _state;
            set
            {
                _state = value;
                foreach (var handler in SceneStateHandlers)
                {
                    handler.State = value;
                }
                _realityObejcts.SetActive(value == SceneState.Reality);
                _dreamObejcts.SetActive(value == SceneState.Dream);
            }
        }
        public void InitializeState()
        {
            State = SceneState.Reality;
        }
        public void ChangeState()
        {
            if (State == SceneState.Reality)
            {
                State = SceneState.Dream;
            }
            else
            {
                State = SceneState.Reality;
            }
        }
    }        
}
