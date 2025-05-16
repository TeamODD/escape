namespace Assets.Scripts.UI.Options
{
    using System.Collections.Generic;
    using UnityEngine;

    public class OptionInitializer : MonoBehaviour
    {
        [SerializeField] private OptionManager _optionManager;
        public void InitializeOption()
        {
            _optionManager.ChangeSprites(0);
        }
    }
}