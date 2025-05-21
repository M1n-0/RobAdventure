using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class rope : MonoBehaviour
{
    public Transform StartPosition;
    public Transform EndPosition;
    public Transform PlayerPosition;
    public GameObject Player;
    private float speed = 1f;
    public static bool isInInteraction = false;
    public bool isIn = false;

    Rigidbody rb; 
    void Start(){
        isInInteraction = false;
        isIn = false;
        rb = Player.GetComponent<Rigidbody>();
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
            isInInteraction = false;
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        }
    }

    void Update(){
        if (isIn){
            if (Input.GetKeyDown(KeyCode.E)){
                Debug.Log("Key E pressed while in triggerbox");
                isInInteraction = true;
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                PlayerPosition.position = StartPosition.position;
            }
            if (isInInteraction){
                
                rb.useGravity = false;
                Vector3 rayOrigin = PlayerPosition.position;
                Debug.Log("Go Up function called");

                float verticalInput = Input.GetAxisRaw("Vertical");
        
                Vector3 moveDirection = new Vector3(0, verticalInput, 0).normalized;

                if (moveDirection != Vector3.zero)
                {                        
                    rb.AddForce(moveDirection* speed * 50f * Time.deltaTime, ForceMode.Force);
                }
                if (Input.GetKeyDown(KeyCode.Space)){
                    Debug.Log("Key E pressed while in triggerbox, stopping movement");
                    isInInteraction = false;
                    rb.useGravity = true;
                    rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                }
            }
        }
    }
}