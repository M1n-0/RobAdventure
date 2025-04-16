using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class JetPackMovement : MonoBehaviour
{
    [Header("Player Movement details")]
    public float speed = 10f;
    public Rigidbody Rigidbody;
    Vector3 moveDirection;

    [Header("jump & fly")]
    [SerializeField] float jumpForce;
    [SerializeField] float flyforce;
    public Vector3 groundRadiusPosition;
    public float GroundRadius;
    [SerializeField] LayerMask GroundMaks;

    public GameObject GameOverMenu;

    void Start(){
        Time.timeScale = 1;
        Rigidbody = GetComponent<Rigidbody>();


    }
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector3(horizontalInput, 0, 0).normalized;

        Movement();
        jump();
        fly();
    }

    void Movement()
    {
        
        Rigidbody.AddForce(-moveDirection * speed * 100f * Time.deltaTime , ForceMode.Acceleration);
        
    }

    void jump()
    {
        if(isGrounded() && Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            Debug.Log("jump");
            Rigidbody.linearVelocity = new Vector3(Rigidbody.linearVelocity.x, 0f, Rigidbody.linearVelocity.z);
            Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void fly()
    {
        if(Input.GetKey(KeyCode.Joystick1Button3) && !isGrounded())
        {
            Rigidbody.AddForce(Vector3.up * flyforce * 100f * Time.deltaTime, ForceMode.Force);
        }
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(transform.position + groundRadiusPosition, GroundRadius, GroundMaks);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + groundRadiusPosition, GroundRadius);
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Entered trigger");
        if (other.CompareTag("Obstacle")){
            GameOverMenu.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
}
