using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KeyTrigger;

public class ConsoleTrigger : MonoBehaviour
{
    [Header("Material")]
    //public Material[] materials;
    //Renderer rend;
    public GameObject openButton;
    public GameObject lockButton;
    public GameObject panelEnigme;
    public GameObject question1;
    public GameObject question2;
    public GameObject question3;

    public static bool isNotDumb = false;

    public static bool isInInteraction;
    private bool isIn;
    private int numQuestion;

    void Start()
    {
        openButton.SetActive(false);
        lockButton.SetActive(true);
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        //rend.sharedMaterial = materials[0];
        isInInteraction = false;
        isIn = false;
        numQuestion = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(keyCollected){
            //rend.sharedMaterial = materials[1];
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
                isInInteraction = false;
            }
            isIn = false;
        }
    }

    private void detectInterraction(){
        if (isIn){
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button1)){
                Debug.Log("Key E pressed while in triggerbox");
                if (isInInteraction){
                    isInInteraction = false;
                }
                else{
                    isInInteraction = true;
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
        }
        else{
            panelEnigme.SetActive(false);
            question1.SetActive(false);
            question2.SetActive(false);
            question3.SetActive(false);
        }
    }
    public void goodAnswer(){
        lockButton.SetActive(false);
        openButton.SetActive(true);
        isInInteraction = false;
        keyCollected = false;
        isNotDumb = true;
        panelInterraction();
    }
    public void wrongAnswer(){
        int previousQuestion = numQuestion;
        while(previousQuestion == numQuestion){
            numQuestion = Random.Range(0, 3);
        }
        isInInteraction = false;
    }
    public bool inInteraction(){
        return isInInteraction;
    }
}
