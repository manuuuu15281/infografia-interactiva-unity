using UnityEngine;
using UnityEngine.UI;

public class UIExplanationOverlay : MonoBehaviour
{
    [Header("Overlay References")]
    public GameObject explanationOverlay;
    public Image explanationImage;

    [Header("Objects To Hide When Overlay Opens")]
    public GameObject linesContainer;

    public void OpenOverlay(Sprite newExplanationSprite, float rotationZ)
    {
        if (explanationOverlay != null)
        {
            explanationOverlay.SetActive(true);
        }

        if (linesContainer != null)
        {
            linesContainer.SetActive(false);
        }

        if (explanationImage != null && newExplanationSprite != null)
        {
            explanationImage.sprite = newExplanationSprite;
            explanationImage.preserveAspect = true;
            explanationImage.rectTransform.localRotation = Quaternion.Euler(0, 0, rotationZ);
        }
    }

    public void CloseOverlay()
    {
        if (explanationOverlay != null)
        {
            explanationOverlay.SetActive(false);
        }

        if (linesContainer != null)
        {
            linesContainer.SetActive(true);
        }

        if (explanationImage != null)
        {
            explanationImage.rectTransform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}