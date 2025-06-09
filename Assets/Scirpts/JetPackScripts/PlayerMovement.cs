//made by NepNath 
//Creation Date: 27/11/2024
//last edited: 18/12/2024

// This script is made for a student project called "RobAdventure".
// These inputs are designed for a specific set of controller handmade,
// based on a arcade machine (arcade joystick and 4 buttons)


using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement details")]
    Vector3 moveDirection;
    Animator animate;
    public float speed = 10f;
    public float JumpForce = 10;
    [SerializeField] float jetpackForce;
    Rigidbody Rigidbody;
    public float TurnSpeed;
    [SerializeField] float Gravity;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector3 groundRadiusPosition;
    public float groundRadius;
    [Header("Raycast propeties")]
    [HideInInspector] public string groundTag = "JumpTrigger";

    private bool isAlive = true;
    
    public ConsoleTrigger interactible;
    public GameObject GameOverMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        animate = GetComponent<Animator>();
        Time.timeScale = 1;
        isAlive = true;
    }


    void Update()
    {
        jump();
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        if (!interactible.inInteraction())
        {
          if(isGrounded())
            {
                Debug.Log("Is Grounded");
            }

            if(!isGrounded())
            {
                Rigidbody.linearDamping = 3.5f;
            }
            else
            {
                Rigidbody.linearDamping = 10f;
            }
        
            addedGravity();

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
        
            moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

       
            if ((isGrounded() && horizontalInput != 0) || (isGrounded() && verticalInput != 0))
            {
                animate.SetBool("Running",true);
                Rigidbody.AddForce(moveDirection * speed * 100f * Time.deltaTime, ForceMode.Force);
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
            }else if ((!isGrounded() && horizontalInput != 0) || (!isGrounded() && verticalInput != 0))
            {
                animate.SetBool("Running",true);
                Rigidbody.AddForce(moveDirection * speed * 25f * Time.deltaTime, ForceMode.Force);
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
            }
            else
            {
                animate.SetBool("Running",false);
            }
        }
        
        
    }


    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            animate.SetBool("Jumping", true);
            Rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        else if ((Input.GetKey(KeyCode.Joystick1Button3) || Input.GetKey(KeyCode.Space)) && !isGrounded())
        {
            Debug.Log("Using Jetpack");
            animate.SetBool("Jetpacking", true);
            Rigidbody.AddForce(Vector3.up * jetpackForce, ForceMode.Acceleration);
        }
        else
        {
            animate.SetBool("Jumping", false);
            animate.SetBool("Jetpacking", false);
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
        Rigidbody.AddForce(Vector3.down * Gravity, ForceMode.Force);
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Entered trigger");
        if (other.CompareTag("Obstacle")){
            GameOverMenu.SetActive(true);
            Time.timeScale = 0;
            isAlive = false;
            Destroy(gameObject);
        }
    }

    public bool Alive(){
        return isAlive;
    }
}