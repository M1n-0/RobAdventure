using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTop : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            int num = Random.Range(0, 3);
            if (num == 0){
                GameObject obs = Instantiate(obstacle1);
                obs.transform.position = new Vector3(-2, 0, 0);
            }
            if (num == 1){
                GameObject obs = Instantiate(obstacle2);
                obs.transform.position = new Vector3(-12, 0, 0);
            }
            if (num == 2){
                GameObject obs = Instantiate(obstacle3);
                obs.transform.position = new Vector3(-15, 0, 0);
            }
            yield return new WaitForSeconds(Random.Range(0.75f, 1.75f));
        }
        
    }
}
