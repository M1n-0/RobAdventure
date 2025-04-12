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
    public GameObject panelEnigme;
    public GameObject question1;
    public GameObject question2;
    public GameObject question3;
    public GameObject question4;

    public static bool isInInteraction = false;
    private bool isIn = false;
    private int numQuestion;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
        isInInteraction = false;
        isIn = false;
        numQuestion = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if(keyCollected){
            rend.sharedMaterial = materials[1];
            detectInterraction();
            panelInterraction();
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

    private void panelInterraction(){
        if (isInInteraction){
            panelEnigme.SetActive(true);
            if (numQuestion == 0){
                question1.SetActive(true);
            }
            if (numQuestion == 1){
                question2.SetActive(true);
            }
            if (numQuestion == 2){
                question3.SetActive(true);
            }
            if (numQuestion == 3){
                question4.SetActive(true);
            }
        }
        else{
            panelEnigme.SetActive(false);
            question1.SetActive(false);
            question2.SetActive(false);
            question3.SetActive(false);
            question4.SetActive(false);
        }
    }
}
