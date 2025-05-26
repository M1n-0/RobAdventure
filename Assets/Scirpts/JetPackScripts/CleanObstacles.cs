using UnityEngine;

public class CleanOstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Obstacle")){
            Destroy(other.gameObject);
        }
    }
}