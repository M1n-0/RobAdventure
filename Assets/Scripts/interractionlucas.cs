using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class interraction : MonoBehaviour
{
    public static bool isInInteraction = false;
    public GameObject InteractionPanelUI;
    private bool isIn = false;

        void Start(){
    isInInteraction = false;
    isIn = false;
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

    void Update(){
        if (isIn){
            if (Input.GetKeyDown(KeyCode.E)){
                Debug.Log("Key E pressed while in triggerbox");
                if (isInInteraction){
                    leave();
                }
                else{
                    interact();
                }
            }
        }
    }
    
  
    void interact(){
        InteractionPanelUI.SetActive(true);
        Debug.Log("activated Pannel");
        isInInteraction = true;
    }
    void leave(){
        InteractionPanelUI.SetActive(false);
        Debug.Log("Desactivated Pannel");
        isInInteraction = false;
    }
}
