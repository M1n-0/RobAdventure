using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBot : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            int num = Random.Range(0, 4);
            if (num == 0){
                GameObject obs = Instantiate(obstacle1);
                obs.transform.position = new Vector3(25, 4, -1);
            }
            if (num == 1){
                GameObject obs = Instantiate(obstacle2);
                obs.transform.position = new Vector3(17, 4, -1);
            }
            if (num == 2){
                GameObject obs = Instantiate(obstacle3);
                obs.transform.position = new Vector3(14, 4, -1);
            }
            if (num == 3){
                GameObject obs = Instantiate(obstacle4);
                obs.transform.position = new Vector3(3, 4, -1);
            }
            yield return new WaitForSeconds(Random.Range(0.75f, 1.75f));
        }
        
    }
}
