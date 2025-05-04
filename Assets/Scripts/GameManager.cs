using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dreamObjects; // DreamObjects ����
    public GameObject realityObjects; // RealityObjects ����

    private bool isInDream = true;

    public void SwitchWorld()
    {
        isInDream = !isInDream;
        dreamObjects.SetActive(isInDream);
        realityObjects.SetActive(!isInDream);
    }

    public bool IsInDream()
    {
        return isInDream;
    }
}
