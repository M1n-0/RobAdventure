using System.Collections;
using UnityEngine;

public class ElectricTrap : MonoBehaviour
{
    public float activeTime = 2f;  // Time the trap is active
    public float inactiveTime = 2f; // Time the trap is inactive
    private Collider trapCollider; // Reference to collider (for 2D)
    private Renderer trapRenderer; // To visually hide the object when inactive

    void Start()
    {
        trapCollider = GetComponent<Collider>();
        trapRenderer = GetComponent<Renderer>();
        StartCoroutine(ToggleTrap());
    }

    IEnumerator ToggleTrap()
    {
        while (true)
        {
            // Activate trap
            trapRenderer.enabled = true;
            trapCollider.enabled = true;
            yield return new WaitForSeconds(activeTime);

            // Deactivate trap
            trapRenderer.enabled = false;
            trapCollider.enabled = false;
            yield return new WaitForSeconds(inactiveTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by trap!");
            Destroy(other.gameObject); // Example: Kill the player (change this to your own damage system)
        }
    }
}
