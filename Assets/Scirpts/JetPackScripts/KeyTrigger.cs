using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public static bool keyCollected = false;

    void Start(){
        keyCollected = false;
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            keyCollected = true;
        }
    }
}
