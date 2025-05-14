using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlinking : MonoBehaviour
{
    [Header("Blink Frequences")]

    public int blinkTime;
    private bool state;
    void Start()
    {
        state = true;
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking(){
        while(true){
        state = !state;
        gameObject.SetActive(state);
        yield return new WaitForSeconds(blinkTime);
        }
    }
}
