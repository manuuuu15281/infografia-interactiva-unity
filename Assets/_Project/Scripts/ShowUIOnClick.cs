using UnityEngine;
using UnityEngine.EventSystems;

public class ShowUIOnClick : MonoBehaviour, IPointerClickHandler
{
    [Header("UI Elements To Show")]
    public GameObject[] objectsToShow;

    [Header("Optional Settings")]
    public bool stopPulseOnClick = true;
    public bool hideThisObjectOnClick = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (objectsToShow != null)
        {
            foreach (GameObject obj in objectsToShow)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }
        }

        if (stopPulseOnClick)
        {
            UIPulse pulse = GetComponent<UIPulse>();

            if (pulse != null)
            {
                pulse.enabled = false;
                transform.localScale = Vector3.one;
            }
        }

        if (hideThisObjectOnClick)
        {
            gameObject.SetActive(false);
        }
    }
}