using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            //if(ending){
            //    yield break;
            //}
            int num = Random.Range(0, 3);
            if (num == 0){
                GameObject obs = Instantiate(obstacle);
                obs.transform.position = new Vector3(12, 7, -2);
            }
            if (num == 1){
                GameObject obs = Instantiate(obstacle);
                obs.transform.position = new Vector3(12, 3, -2);
                obs.transform.eulerAngles = new Vector3(-90, 0, 0); //Trouver la commande pour rotate
            }
            if (num == 2){
                GameObject obs = Instantiate(obstacle);
                obs.transform.position = new Vector3(12, 0, -2);
            }
            yield return new WaitForSeconds(Random.Range(0.75f, 1.75f));
        }
        
    }
}
