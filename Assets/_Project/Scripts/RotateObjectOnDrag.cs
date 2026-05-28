using UnityEngine;

public class RotateObjectOnDrag : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 8f;

    private bool isDragging = false;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckIfClickedOnObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            RotateObject();
        }
    }

    private void CheckIfClickedOnObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform == transform || hit.transform.IsChildOf(transform))
            {
                isDragging = true;
            }
        }
    }

    private void RotateObject()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, -mouseX * rotationSpeed, Space.World);
        transform.Rotate(Vector3.right, mouseY * rotationSpeed, Space.World);
    }
}