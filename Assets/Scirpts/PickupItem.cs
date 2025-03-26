using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float interactionDistance = 5f;
    public Transform player; // Assign this in the Inspector or find the player dynamically

    private void Update()
    {
        // Rotate the cube around the Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        if (player != null && Vector3.Distance(transform.position, player.position) < interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
