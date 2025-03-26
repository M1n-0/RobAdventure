using UnityEngine;

public class doodleCameraFollow : MonoBehaviour
{
    public Transform player;  // The player's transform
    public Vector3 offset;    // The offset from the player to the camera
    public float smoothSpeed = 0.125f; // How smooth the camera follows the player

    void LateUpdate()
    {
        // Calculate the desired position
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Apply the smoothed position to the camera
        transform.position = smoothedPosition;
    }
}
