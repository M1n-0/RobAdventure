using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] GameObject Light;
    [SerializeField] Transform lightspawnpoint;
    public SpawnerTop top;
    public SpawnerMid mid;
    public SpawnerBot bot;
    void Start()
    {
        StartCoroutine(SpawnObjects());
        StartCoroutine(SpawnLight());
    }
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            int num = Random.Range(0, 3);
            if (num == 0)
            {
                top.SpawnTopObstacle();
            }
            if (num == 1)
            {
                mid.SpawnMidObstacle();
            }
            if (num == 2)
            {
                bot.SpawnBotObstacle();
            }
            yield return new WaitForSeconds(Random.Range(0.75f, 1.75f));
        }
    }

    IEnumerator SpawnLight()
    {
        while (true)
        {
            Instantiate(Light, lightspawnpoint.position, lightspawnpoint.rotation);
            Debug.Log("Spawning Light");
            yield return new WaitForSeconds(3f);
        }
    }
}
