using UnityEngine;
using static antigrav;

public class batterie : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Entered trigger");
        if (other.CompareTag("Player"))
        {
            Debug.Log("battery picked up");
            Destroy(gameObject);
        }
    }
}
