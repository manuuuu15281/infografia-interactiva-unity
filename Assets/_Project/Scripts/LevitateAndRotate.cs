using UnityEngine;

public class LevitateAndRotate : MonoBehaviour
{
    [Header("Levitación")]
    public float levitationHeight = 0.3f;
    public float levitationSpeed = 1.5f;

    [Header("Rotación")]
    public float rotationSpeed = 30f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Movimiento suave hacia arriba y abajo
        float newY = startPosition.y + Mathf.Sin(Time.time * levitationSpeed) * levitationHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        // Rotación automática
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}