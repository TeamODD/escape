using UnityEngine;

public class BedSwitcher : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnMouseDown() // 침대를 클릭하면
    {
        gameManager.SwitchWorld();
    }
}
