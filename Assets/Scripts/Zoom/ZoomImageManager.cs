using UnityEngine;
using UnityEngine.Events;

public class ZoomImageManager : MonoBehaviour
{
    [field: SerializeField] public UnityEvent<Sprite> OnShowEvent { get; private set; } = new();
    [field: SerializeField] public UnityEvent OnHideEvent { get; private set; } = new();

    public void Show(Sprite sprite)
    {
        OnShowEvent?.Invoke(sprite);
    }

    public void Hide()
    {
        OnHideEvent?.Invoke();
    }
}