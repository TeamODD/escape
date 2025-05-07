using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject inventory;
    
    public static GameManager Instance{get; private set;}
    [SerializeField] private GameObject _dreamObjects;
    [SerializeField] private GameObject _realityObjects;
    private TotalInventoryController _inventoryScript;
    public bool IsInDream { get; private set; } = false;

    private void Awake()
    {
        // 싱글톤 패턴
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _inventoryScript = inventory.GetComponent<TotalInventoryController>();
        _dreamObjects.SetActive(IsInDream);
        _realityObjects.SetActive(!IsInDream);
        Awake();
    }

    public void SwitchWorld()
    {
        Debug.Log("Switch");
        IsInDream = !IsInDream;
        _dreamObjects.SetActive(IsInDream);
        _realityObjects.SetActive(!IsInDream);
        _inventoryScript.AllInventorySwitchStatus(IsInDream);
       
    }
}