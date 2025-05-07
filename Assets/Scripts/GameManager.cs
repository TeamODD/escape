using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    [SerializeField] private GameObject _dreamObjects;
    [SerializeField] private GameObject _realityObjects;

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
        _dreamObjects.SetActive(IsInDream);
        _realityObjects.SetActive(!IsInDream);
    }

    public void SwitchWorld()
    {
        IsInDream = !IsInDream;
        _dreamObjects.SetActive(IsInDream);
        _realityObjects.SetActive(!IsInDream);
    }
}