using UnityEngine;

public class SpawnerBot : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;

    void Start()
    {

    }
    public void SpawnBotObstacle()
    {
        int num = Random.Range(0, 4);
        if (num == 0){
            GameObject obs = Instantiate(obstacle1);
            obs.transform.position = new Vector3(3.5f, 4, -3);
        }
        if (num == 1){
            GameObject obs = Instantiate(obstacle2);
            obs.transform.position = new Vector3(12, 4, -3);
        }
        if (num == 2){
            GameObject obs = Instantiate(obstacle3);
            obs.transform.position = new Vector3(15, 4, -3);
        }
        if (num == 3){
            GameObject obs = Instantiate(obstacle4);
            obs.transform.position = new Vector3(26, 4, -3);
        }
    }
}
