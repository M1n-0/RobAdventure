using UnityEngine;

public class BatteryBehavior : MonoBehaviour
{

    PlayerBattery PBattery;
    PlayerMovementSerre player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PBattery = other.GetComponent<PlayerBattery>();
            player = other.GetComponent<PlayerMovementSerre>();

            PBattery.totalCount++;
            gameObject.SetActive(false);

        }
    }
}
