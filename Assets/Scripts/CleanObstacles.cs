using UnityEngine;

public class CleanOstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        Debug.Log("Entered trigger");
        if (other.CompareTag("Obstacle")){
            Destroy(other.gameObject);
        }
    }
}