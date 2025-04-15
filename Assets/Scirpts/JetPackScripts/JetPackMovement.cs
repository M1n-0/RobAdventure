using Unity.VisualScripting;
using UnityEngine;
public class JetPackMovement : MonoBehaviour
{
    [Header("Mouvement Général")]
    public float walkSpeed = 7f;
    public float sprintSpeed = 12f;
    public float gravity = -9.81f;
    public float TurnSpeed = 20f;


    [Header("References")]
    public Camera playerCamera;
    public LayerMask Ground;
    PlayerMovement pm;
    public float CharaControlHeightExtend = 0.2f;

    [Header("PlayerInput")]
    float horizontalInput;
    float verticalInput;


    [Header("jetpack")]
    public float flyForce;
    public bool isUsingJetPack;
   


    [Header("Raycast Colors")]
    public Color WallRay;
    public Color LookRay;
    public Color GroundedRay;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isRayGrounded;
    private float originalHeight;
    private Vector3 previousPosition;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
        previousPosition = transform.position;
        pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {

        //--------------------------making variables--------------------------
        isRayGrounded = Physics.Raycast(transform.position, -transform.up, controller.height * CharaControlHeightExtend, Ground);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontalInput, 0f, 0f);
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(move * walkSpeed * Time.deltaTime);
        // --------------------------------------------------------------------



        //--------------------------calling methods--------------------------
        RaycastsDraw();
        textDebug();
        PlayerRotation();
        fly();
        //--------------------------------------------------------------------
    }

    private void RaycastsDraw()
    {
        Debug.DrawRay(transform.position, -transform.up * controller.height * CharaControlHeightExtend, GroundedRay);
    }


    private void textDebug()
    {
        if(isRayGrounded)
        {
            Debug.Log("Player Is Grounded by Raycast");
        }
        if(isUsingJetPack)
        {
            Debug.Log("UsingJetPack");
        }
    }

    private void PlayerRotation()
    {
        Vector3 move = new Vector3(horizontalInput, 0f, 0f);
        Quaternion targetRotation = Quaternion.LookRotation(move, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Inverse(targetRotation), TurnSpeed * Time.deltaTime);
    }

    private void fly()
    {
        isUsingJetPack = Input.GetKey(KeyCode.Space);
        if(isUsingJetPack)
        {
            velocity.y = flyForce;
        }
        
        controller.Move(velocity * Time.deltaTime);
    }
}
