using UnityEngine;

public class SpawnerMid : MonoBehaviour
{
    public GameObject obstacle;

    void Start()
    {
        
    }
    public void SpawnMidObstacle()
    {
        GameObject obs = Instantiate(obstacle);
        obs.transform.position = new Vector3(13, 3, -1);
    }
}
