using UnityEngine;

public class cammvt : MonoBehaviour
{
    public Transform player;
    public antigrav antigravScript; // Reference to the antigrav script

    private void Start()
    {
        // Check if player is assigned
        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned.");
        }

        // Check if antigravScript is assigned
        if (antigravScript == null)
        {
            Debug.LogError("antigravScript is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (antigravScript != null)
        {
            float ztrans = antigravScript.ztrans;
            transform.position = player.transform.position + new Vector3(0f, 0.25f, ztrans);
        }
    }
}