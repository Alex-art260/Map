using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 10;

    private Camera zoomCamera;
    private float dragSpeed = 0.01f;
    private float timeDragStarted;
    private Vector3 previousPosition = Vector3.zero;

    private void Start()
    {
        zoomCamera = Camera.main;
        zoomCamera.orthographicSize = 20;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timeDragStarted = Time.time;
            dragSpeed = 0f;
            previousPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0) && Time.time - timeDragStarted > 0.05f)
        {
            Vector3 input = Input.mousePosition;
            float deltaX = (previousPosition.x - input.x) * dragSpeed;
            float deltaY = (previousPosition.y - input.y) * dragSpeed;

            float newX = Mathf.Clamp(transform.position.x + deltaX, -12, 200.0f);

            float newY = Mathf.Clamp(transform.position.y + deltaY, -55, 3f);

            transform.position = new Vector3(
                newX,
                newY,
                transform.position.z);

            previousPosition = input;

            if (dragSpeed < 0.1f) dragSpeed += 0.002f;
        }

        if (zoomCamera.orthographic)
        {
            zoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            zoomCamera.orthographicSize = Mathf.Clamp(zoomCamera.orthographicSize, 10f, 40f);
        }
    }
}
