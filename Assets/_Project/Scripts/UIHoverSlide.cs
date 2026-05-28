using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverSlide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Hover Movement")]
    public float moveAmount = 20f;
    public float moveSpeed = 4f;

    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private Coroutine hoverCoroutine;
    private bool isHovering = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;

        if (hoverCoroutine == null)
        {
            hoverCoroutine = StartCoroutine(HoverMovement());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;

        if (hoverCoroutine != null)
        {
            StopCoroutine(hoverCoroutine);
            hoverCoroutine = null;
        }

        rectTransform.anchoredPosition = originalPosition;
    }

    private IEnumerator HoverMovement()
    {
        while (isHovering)
        {
            float offsetX = Mathf.Sin(Time.time * moveSpeed) * moveAmount;
            rectTransform.anchoredPosition = originalPosition + new Vector2(offsetX, 0);

            yield return null;
        }
    }
}