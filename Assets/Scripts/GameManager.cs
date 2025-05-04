using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dreamObjects; // DreamObjects 폴더
    public GameObject realityObjects; // RealityObjects 폴더

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
