using UnityEngine;

public class PulseAnimation : MonoBehaviour
{
    [Header("Pulso")]
    public float pulseSpeed = 2f;
    public float minScale = 1.1f;
    public float maxScale = 1.4f;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float pulse = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);

        transform.localScale = originalScale * pulse;
    }
}