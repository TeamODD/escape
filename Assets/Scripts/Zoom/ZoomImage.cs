using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Animators;

public class ZoomImage : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Image image;
    [SerializeField] private FadeInAnimator fadeInAnimator;
    [SerializeField] private FadeOutAnimator fadeOutAnimator;

    private void Start()
    {
        var manager = FindObjectOfType<ZoomImageManager>();
        manager.OnShowEvent.AddListener(OnShow);
        manager.OnHideEvent.AddListener(OnHide);
    }

    public void OnShow(Sprite sprite)
    {
        image.sprite = sprite;
        panel.SetActive(true);
        fadeInAnimator.PlayAnimation();
    }

    public void OnHide()
    {
        fadeOutAnimator.PlayAnimation();
    }
}