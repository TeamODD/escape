using UnityEngine;

public class BedSwitcher : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnMouseDown() // ħ�븦 Ŭ���ϸ�
    {
        gameManager.SwitchWorld();
    }
}
