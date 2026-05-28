using UnityEngine;

public class ObjectClickInteraction : MonoBehaviour
{
    [Header("UI")]
    public GameObject infoContainer;

    [Header("Indicador visual")]
    public GameObject pulseIndicator;

    private bool hasBeenClicked = false;

    private void OnMouseDown()
    {
        Debug.Log("CLIC DETECTADO EN EL TERMO");

        if (hasBeenClicked) return;

        hasBeenClicked = true;

        if (infoContainer != null)
        {
            infoContainer.SetActive(true);
        }

        if (pulseIndicator != null)
        {
            pulseIndicator.SetActive(false);
        }
    }
}