using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot(){
        while(true){
            GameObject laser = Instantiate(projectile);
            laser.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        yield return new WaitForSeconds(Random.Range(0.75f, 1.75f));
        }
    }
}
