namespace Assets.Scripts.Escape.Inventory
{
    using System.Collections.Generic;
    using UnityEngine;
    using Sirenix.OdinInspector;
    using UnityEngine.UI;

    public class InventoryManager : SerializedMonoBehaviour, ISceneStateHandler
    {
        public static InventoryManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            Instance = this;
        }
        [field: SerializeField] public Dictionary<string, ItemData> ItemDictionary { get; private set; }
        [SerializeField] private Sprite _realityBackgroundSprite;
        [SerializeField] private Sprite _dreamBackgroundSprite;
        [SerializeField] private Image _BackgroundImage;
        [SerializeField] private List<InventoryPage> _inventoryPages;
        [SerializeField] private ItemSlot[] _itemSlots = new ItemSlot[5];
        
        [SerializeField] private int _pageIndex;
        [SerializeField] private Button _prevPageButton;
        [SerializeField] private Button _nextPageButton;
        public void MovePrevPage()
        {
            if (_pageIndex <= 0)
            {
                Debug.Log("이전 페이지가 존재하지 않습니다.");
                return;
            }
            _pageIndex--;
            SetItemSlots();
            if (_pageIndex <= 0)
            {
                _prevPageButton.interactable = false;
            }
            _nextPageButton.interactable = true;
        }
        public void MoveNextPage()
        {
            if (_pageIndex >= _inventoryPages.Count - 1)
            {
                Debug.Log("다음 페이지가 존재하지 않습니다.");
                return;
            }
            _pageIndex++;
            SetItemSlots();
            if (_pageIndex >= _inventoryPages.Count - 1)
            {
                _nextPageButton.interactable = false;
            }
            _prevPageButton.interactable = true;
        }

        public void SetItemSlots()
        {
            InventoryPage page = _inventoryPages[_pageIndex];
            if (State == SceneState.Reality)
            {
                for (int i = 0; i < _itemSlots.Length; i++)
                {
                    _itemSlots[i].ItemData = page.RealityItemDataArray[i];
                }
            }
            else
            {
                for (int i = 0; i < _itemSlots.Length; i++)
                {
                    _itemSlots[i].ItemData = page.DreamItemDataArray[i];
                }
            }
        }

        private SceneState _state;
        public SceneState State
        {
            get => _state;
            set
            {
                _state = value;
                SetItemSlots();
            }
        }
        public void InitializeState()
        {
            State = SceneState.Reality;
        }

        public void AcquireItem(ItemData data)
        {
            string name = data.Name;
            if (ItemDictionary.TryGetValue(name, out var item))
            {
                item.IsAcquired = true;
                foreach (var itemSlot in _itemSlots)
                {
                    if (itemSlot.ItemData != null && itemSlot.ItemData.Name == name)
                    {
                        itemSlot.ItemImage.gameObject.SetActive(true);
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("아이템 정보가 없습니다 : " + name);
            }
        }
    }        
}
