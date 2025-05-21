using UnityEngine;

public class SpawnerTop : MonoBehaviour
{
    public GameObject obstacle;

    void Start()
    {
        
    }
    public void SpawnTopObstacle()
    {
        GameObject obs = Instantiate(obstacle);
        obs.transform.position = new Vector3(8, 4.1f, -3.7f);
    }
}
