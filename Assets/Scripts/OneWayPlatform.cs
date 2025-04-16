using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ignore collisions when passing from below
            Physics.IgnoreCollision(other.GetComponent<Collider>(), transform.parent.GetComponent<Collider>(), true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Re-enable collisions when the player exits the bottom trigger
            Physics.IgnoreCollision(other.GetComponent<Collider>(), transform.parent.GetComponent<Collider>(), false);
        }
    }
}
