namespace Assets.Scripts.Escape
{
    using UnityEngine;
    using Sirenix.OdinInspector;
    using System.Collections.Generic;
    using Assets.Scripts.UI.Options;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class SceneManager : SerializedMonoBehaviour, ISceneStateHandler
    {
        [field: SerializeField] public List<ISceneStateHandler> SceneStateHandlers { get; private set; }
        [field: SerializeField] private SceneState _state;
        [field: SerializeField] private GameObject _realityObejcts;
        [field: SerializeField] private GameObject _dreamObejcts;


        [field: SerializeField] private Image _dialogueImage;
        [field: SerializeField] private Image _itemDialogueImage;
        [field: SerializeField] private Sprite _realityDialogueSprite;
        [field: SerializeField] private Sprite _dreamDialogueSprite;


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
                _dreamObejcts.SetActive(value == SceneState.Dream);
                _realityObejcts.SetActive(value == SceneState.Reality);
                if (value == SceneState.Reality)
                {
                    _dialogueImage.sprite = _realityDialogueSprite;
                    _itemDialogueImage.sprite = _realityDialogueSprite;
                }
                else
                {
                    _dialogueImage.sprite = _dreamDialogueSprite;
                    _itemDialogueImage.sprite = _dreamDialogueSprite;
                }
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
            if (OptionManager.Instance != null)
            {
                OptionManager.Instance.ChangeSprites();
            }
        }
    }        
}
