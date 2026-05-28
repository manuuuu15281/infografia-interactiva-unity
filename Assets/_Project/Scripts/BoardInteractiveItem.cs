using UnityEngine;
using UnityEngine.EventSystems;

public class BoardInteractiveItem : MonoBehaviour, IPointerClickHandler
{
    [Header("Overlay Manager")]
    public UIExplanationOverlay overlayManager;

    [Header("Explanation Image")]
    public Sprite explanationSprite;

    [Header("Explanation Settings")]
    public float explanationRotationZ = 0f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (overlayManager != null && explanationSprite != null)
        {
            overlayManager.OpenOverlay(explanationSprite, explanationRotationZ);
        }
    }
}