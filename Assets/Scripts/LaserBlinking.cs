using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlinking : MonoBehaviour
{
    [Header("Blinker")]

    public GameObject blinker;

    [Header("Blink Frequences")]

    public float blinkTime;
    public float interval;
    private bool state;
    private float timer = 0f;
    private bool isRotated = false;
    void Start()
    {
        state = true;
        StartCoroutine(Blinking());
    }

    void Update()
    {
        if (state){
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                float xRotation = isRotated ? 0f : 180f;
                blinker.transform.rotation = Quaternion.Euler(xRotation, blinker.transform.rotation.eulerAngles.y, blinker.transform.rotation.eulerAngles.z);
                isRotated = !isRotated;
                timer = 0f;
            }
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
