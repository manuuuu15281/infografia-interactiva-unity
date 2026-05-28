using UnityEngine;

public class XRayRevealController : MonoBehaviour
{
    [Header("References")]
    public RectTransform xRaySystem;
    public RectTransform xRayMask;
    public RectTransform interiorImage;

    [Header("Settings")]
    public bool xRayEnabled = false;

    private void Start()
    {
        if (xRayMask != null)
        {
            xRayMask.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!xRayEnabled) return;

        MoveMaskWithMouse();
    }

    public void EnableXRay()
    {
        xRayEnabled = true;

        if (xRayMask != null)
        {
            xRayMask.gameObject.SetActive(true);
        }
    }

    public void DisableXRay()
    {
        xRayEnabled = false;

        if (xRayMask != null)
        {
            xRayMask.gameObject.SetActive(false);
        }
    }

    private void MoveMaskWithMouse()
    {
        Vector2 localMousePosition;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            xRaySystem,
            Input.mousePosition,
            null,
            out localMousePosition
        );

        xRayMask.anchoredPosition = localMousePosition;

        if (interiorImage != null)
        {
            interiorImage.anchoredPosition = -localMousePosition;
        }
    }
}