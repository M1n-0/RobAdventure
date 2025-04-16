using UnityEngine;

public class exit : MonoBehaviour
{
    private Collider exitCollider;
    private Renderer exitRenderer;
    private antigrav playerScript;

    private void Start()
    {
        exitCollider = GetComponent<Collider>();
        exitRenderer = GetComponent<Renderer>();
        playerScript = Object.FindFirstObjectByType<antigrav>();
    }

    private void Update()
    {
        if (playerScript.battery >= 4)
        {
            exitCollider.enabled = false; // Make the object intangible
            exitRenderer.enabled = false; // Optionally make the object invisible
        }
        else
        {
            exitCollider.enabled = true; // Make the object tangible
            exitRenderer.enabled = true; // Optionally make the object visible
        }
    }
}