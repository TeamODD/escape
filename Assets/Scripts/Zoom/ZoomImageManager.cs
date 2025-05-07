using UnityEngine;

public class ZoomImageManager : MonoBehaviour
{
    public GameObject ZoomImagPanel;
    
    
    public Sprite DefaultZoomeSprite;
    
    private static ZoomImageManager _instance;
    public static ZoomImageManager Instance => _instance;

    private void Awake()
    {
        _instance = this;
        ZoomImagPanel.SetActive(false);
    }

    public void ShowZoomImage(Sprite image)
    {

    }
}
