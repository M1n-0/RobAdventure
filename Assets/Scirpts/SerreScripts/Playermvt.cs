
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovementSerre : MonoBehaviour
{

    [Header ("References")]
    public bool IsInJump;

    [Header("Player Movement details")]
    Vector3 moveDirection;
    public float speed = 10f;
    float leafSpeed = 4f;
    public float JumpForce = 10;
    Rigidbody Rigidbody;
    public float TurnSpeed;
    public bool hasLeaf;
    [SerializeField] float Gravity;
    [SerializeField] float LeafGravity;
    [SerializeField] LayerMask groundLayer;
    
    [SerializeField] GameObject InfoCanva;
    [SerializeField] Vector3 groundRadiusPosition;
    public float groundRadius;
    [Header("Raycast propeties")]
    [HideInInspector] public string groundTag = "JumpTrigger";
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        jump();
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        if(isGrounded())
        {
            Debug.Log("Is Grounded");
            Rigidbody.linearDamping = 10f;

        }

        if(!isGrounded())
        {
            Rigidbody.linearDamping = 2f;
        }else if(!isGrounded() && hasLeaf)
        {
            Rigidbody.linearDamping = 2f;
        }
        
        addedGravity();

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        
        moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

       
        if (isGrounded())
        {
            Rigidbody.AddForce(moveDirection * speed * 100f * Time.deltaTime, ForceMode.Force);
            if (horizontalInput != 0 || verticalInput != 0)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);    
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
            }
        }else if (hasLeaf && !isGrounded())
        {
            Rigidbody.AddForce(moveDirection * speed * 10f * Time.deltaTime, ForceMode.Force);
            if (horizontalInput != 0 || verticalInput != 0)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);    
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
            }
        }else if (!isGrounded())
        {
            Rigidbody.AddForce(moveDirection * speed * 25f * Time.deltaTime, ForceMode.Force);
            if (horizontalInput != 0 || verticalInput != 0)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);    
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
            }
        }
        
    }
    

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            
            Rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(transform.position - groundRadiusPosition, groundRadius, groundLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position - groundRadiusPosition, groundRadius);
    }

    void addedGravity()
    {
        if(!hasLeaf)
        {
            Rigidbody.AddForce(Vector3.down * Gravity, ForceMode.Force);
        }
        else if(hasLeaf && !isGrounded())
        {
            Rigidbody.AddForce(Vector3.down * LeafGravity, ForceMode.Force);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CamPos2"))
        {
            IsInJump = true;
        }
        
    }
    void OnTriggerExit(Collider other)
    {       
        IsInJump = false;
    }
}