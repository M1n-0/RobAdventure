using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class interraction : MonoBehaviour
{
    public static bool isInInteraction = false;
    public GameObject InteractionPanelUI;
    private bool isIn = false;
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            isIn = true;
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            if (isInInteraction){
                leave();
            }
            isIn = false;
        }
    }
    void Update(){
        if (isIn){
            if (Input.GetKeyDown(KeyCode.Space)){
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
        isInInteraction = true;
    }
    void leave(){
        InteractionPanelUI.SetActive(false);
        isInInteraction = false;
    }
}
