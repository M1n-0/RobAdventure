using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [Header("To Destroy")]
    public GameObject door;

    public static bool isInInteraction = false;
    private bool isIn = false;

    void Start()
    {
        isInInteraction = false;
        isIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        detect();
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
            isIn = false;
        }
    }
  
    private void detect(){
        if (isIn){
            if (Input.GetKeyDown(KeyCode.E)){
                Debug.Log("Key E pressed while in triggerbox");
                Destroy(door);
            }
        }
    }
}
