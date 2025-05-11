using UnityEngine;

public class ZoomTarget : MonoBehaviour
{
    [SerializeField] private Sprite targetSprite;
    private ZoomImageManager manager;

    private void Start()
    {
        manager = FindObjectOfType<ZoomImageManager>();
    }

    private void OnMouseDown()
    {
        manager.Show(targetSprite);
    }
}