using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlinking : MonoBehaviour
{
    [Header("Blinker")]

    public GameObject blinker;

    [Header("Blink Frequences")]

    public float blinkTime;
    public float animSpeed;
    private bool state;
    private float degree;
    void Start()
    {
        state = true;
        degree = 0;
        Quaternion rotate = Quaternion.Euler(0, 0, 0);
        blinker.transform.rotation = Quaternion.Slerp(transform.rotation, rotate, animSpeed * Time.deltaTime);
        //StartCoroutine(Blinking());
    }

    void Update()
    {
        if (degree == 0)
        {
            Quaternion rotate = Quaternion.Euler(degree, 0, 0);
            blinker.transform.rotation = Quaternion.Slerp(transform.rotation, rotate, animSpeed * Time.deltaTime);
            degree = 180;
        }
        else
        {
            Quaternion rotate = Quaternion.Euler(degree, 0, 0);
            blinker.transform.rotation = Quaternion.Slerp(transform.rotation, rotate, animSpeed * Time.deltaTime);
            degree = 0;
        }
    }

    IEnumerator Blinking(){
        while(true){
        state = !state;
        blinker.SetActive(state);
        yield return new WaitForSeconds(blinkTime);
        }
    }
}
