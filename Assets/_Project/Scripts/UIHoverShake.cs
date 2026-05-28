using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHoverShake : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Shake Settings")]
    public float shakeAmount = 6f;
    public float rotationAmount = 3f;
    public float shakeSpeed = 25f;

    [Header("Click Detection")]
    public float alphaThreshold = 0.1f;

    private RectTransform rectTransform;
    private Image image;

    private Vector2 originalPosition;
    private Quaternion originalRotation;

    private bool isHovering = false;
    private Coroutine shakeCoroutine;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        originalPosition = rectTransform.anchoredPosition;
        originalRotation = rectTransform.localRotation;

        if (image != null)
        {
            image.raycastTarget = true;
            image.alphaHitTestMinimumThreshold = alphaThreshold;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;

        if (shakeCoroutine == null)
        {
            shakeCoroutine = StartCoroutine(Shake());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopShake();
    }

    private void StopShake()
    {
        isHovering = false;

        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
            shakeCoroutine = null;
        }

        rectTransform.anchoredPosition = originalPosition;
        rectTransform.localRotation = originalRotation;
    }

    private IEnumerator Shake()
    {
        while (isHovering)
        {
            float shakeX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            float shakeRotation = Mathf.Sin(Time.time * shakeSpeed * 1.2f) * rotationAmount;

            rectTransform.anchoredPosition = originalPosition + new Vector2(shakeX, 0);
            rectTransform.localRotation = Quaternion.Euler(0, 0, shakeRotation);

            yield return null;
        }
    }
}