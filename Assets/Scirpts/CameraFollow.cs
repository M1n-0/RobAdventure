using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign the player in the Inspector
    public float minHeight = 0f; // Set a reasonable minimum height
    public float maxHeight = 10f; // Set a reasonable maximum height

    private float fixedX;
    private float fixedZ;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned to CameraFollow script!");
            return;
        }

        // Store initial X and Z positions of the camera
        fixedX = transform.position.x;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Get the player's Y position and clamp it within the min and max height range
            float clampedY = Mathf.Clamp(player.position.y, minHeight, maxHeight);

            // Update camera position with constraints
            transform.position = new Vector3(fixedX, clampedY, fixedZ);
        }
    }
}
