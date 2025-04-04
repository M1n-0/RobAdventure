using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KeyTrigger;

public class ConsoleTrigger : MonoBehaviour
{
    [Header("Material")]
    public Material[] materials;
    Renderer rend;
    public GameObject cage;

    public static bool isInInteraction = false;
    private bool isIn = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
        isInInteraction = false;
        isIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(keyCollected){
            rend.sharedMaterial = materials[1];
            detectInterraction();
        }
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("Entered trigger");
        if (other.CompareTag("Player")){
            isIn = true;
        }
    }

    private void OnTriggerExit(Collider other){
        Debug.Log("Exited Trigger"); 
        if (other.CompareTag("Player")){
            if (isInInteraction){
                leave();
            }
            isIn = false;
        }
    }
  
    void interact(){
        Debug.Log("activated Pannel");
        isInInteraction = true;
    }

    void leave(){
        Debug.Log("Desactivated Pannel");
        isInInteraction = false;
    }

    private void detectInterraction(){
        if (isIn){
            if (Input.GetKeyDown(KeyCode.E)){
                Debug.Log("Key E pressed while in triggerbox");
                if (isInInteraction){
                    leave();
                }
                else{
                    interact();
                    Destroy(cage);
                }
            }
        }
    }
}
