using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [Header("To Destroy")]
    public GameObject leftDoor;
    public GameObject rightDoor;

    public static bool isInInteraction = false;
    private bool isIn = false;
    private bool isOpen = false;

    private Coroutine openLeft;
    private Coroutine openRight;

    void Start()
    {
        isInInteraction = false;
        isIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        detect();
        if (isOpen){
            Destroy(leftDoor);
            Destroy(rightDoor);
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
                openLeft = StartCoroutine(openingDoor(leftDoor, 1));
                openRight = StartCoroutine(openingDoor(rightDoor, -1));
            }
        }
    }

    IEnumerator openingDoor(GameObject door, int movement){
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
