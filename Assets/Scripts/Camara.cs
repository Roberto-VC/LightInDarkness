using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player; // Assign the player transform in the Inspector
    [SerializeField]
    private Vector3 offset; // Offset from the player's position
    [SerializeField]
    private float distance = 5f; // Distance from the player
    [SerializeField]
    private float height = 2f; // Height above the player
    [SerializeField]
    private float rotationSpeed = 5f; // Speed of camera rotation
    [SerializeField]
    private float smoothSpeed = 0.125f; // Smoothing speed

    private void LateUpdate()
    {
        // Get mouse input for rotation
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Rotate the camera around the player
        transform.RotateAround(player.position, Vector3.up, horizontalInput);
        transform.RotateAround(player.position, transform.right, -verticalInput);

        // Calculate the desired position
        Vector3 desiredPosition = player.position + offset + new Vector3(0, height, -distance);
        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Make the camera look at the player
    }
}
