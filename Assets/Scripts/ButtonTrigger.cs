using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [Header("Doors to Open")]
    public GameObject door;

    public static bool isInInteraction = false;
    private bool isIn = false;
    private bool isOpen = false;
    private bool destroyed = false;

    private Coroutine openDoor;

    void Start()
    {
        isInInteraction = false;
        isIn = false;
        isOpen = false;
        destroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        detect();
        if (isOpen && !destroyed){
            Destroy(door);
            destroyed = true;
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
            isIn = false;
        }
    }
  
    private void detect(){
        if (isIn){
            if (Input.GetKeyDown(KeyCode.E)){
                Debug.Log("Key E pressed while in triggerbox");
                openDoor = StartCoroutine(openingDoor(1));
            }
        }
    }

    IEnumerator openingDoor(int movement){
        float loop = 2;
        while(loop >= 0){
            door.transform.position += new Vector3(0, 0, movement)* 10 * Time.deltaTime;
            yield return new WaitForSeconds(0.15f);
            loop -= 0.15f;
        }
        isOpen = true;
        yield break;
    }
}
