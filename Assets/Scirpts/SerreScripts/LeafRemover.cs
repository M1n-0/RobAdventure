using UnityEngine;

public class LeafRemover : MonoBehaviour
{
    PlayerMovementSerre Player;

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.GetComponent<PlayerMovementSerre>();
            Player.hasLeaf = false;
        }
    }
}
