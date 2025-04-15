using UnityEngine;
using System.Collections;
using TMPro;
using NUnit.Framework.Internal;

public class CCPlayerMovement : MonoBehaviour
{
    [Header("Mouvement Général")]
    public float walkSpeed = 7f;
    public float sprintSpeed = 12f;
    public float gravity = -9.81f;
   
    
    Vector3 moveDirection;
    Vector3 move;

    [Header("References")]
    public Camera playerCamera;
    public LayerMask Ground;
    PlayerMovement pm;

    [Header("PlayerInput")]
    float horizontalInput;
    float verticalInput;



    [Header("Dash")]
    public float dashForce = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    private bool canDash = true;

    [Header("jump")]
     public float jumpHeight = 2f;
    public float CharaControlHeightExtend;

    [Header("Wall Jump")]
    public float wallJumpForce = 10f;
    public LayerMask wallLayer;
    public float wallJumpDetectionRange = 1f;

    [Header("Slide")]
    public float slideSpeed = 15f;
    public float slideDuration = 0.5f;

    [Header("UI")]
    public TextMeshProUGUI VelocityText;
    public TextMeshProUGUI PlayerStateText;
    public TextMeshProUGUI PlayerFOVText;
    public TextMeshProUGUI PlayerHealthText;

    [Header("Raycast Colors")]
    public Color WallRay;
    public Color LookRay;
    public Color GroundedRay;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isRayGrounded;
    private bool isDashing = false;
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
        move = transform.forward * verticalInput + transform.right * horizontalInput; 
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        // --------------------------------------------------------------------



        //--------------------------calling methods--------------------------
        UpdateUI();
        RaycastsDraw();
        PlayerMovement();
        Dash();
        textDebug();
        //--------------------------------------------------------------------
    }


    private void PlayerMovement()
    {
        float speed = walkSpeed;

        if (isRayGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        if (!isDashing)
        {
            controller.Move(move.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isRayGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash(move));
        }
    }

    private IEnumerator Dash(Vector3 direction)
    {
        canDash = false;
        isDashing = true;
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            controller.Move(direction.normalized * dashForce * Time.deltaTime);
            yield return null;
        }
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }


    private void UpdateUI()
    {
        if (VelocityText != null)
        {
            Vector3 currentPosition = transform.position;
            float velocityMagnitude = (currentPosition - previousPosition).magnitude / Time.deltaTime;
            previousPosition = currentPosition;

            VelocityText.text = "Vitesse : " + velocityMagnitude.ToString("F2");
            if (velocityMagnitude > 21)
            {
                VelocityText.color = Color.red;
                VelocityText.text = "Vitesse : " + velocityMagnitude.ToString("F2") + " ! ! !";
            }
            else
            {
                VelocityText.color = Color.white;
            }
        }

        if (PlayerFOVText != null)
        {
            PlayerFOVText.text = "Actual FOV : " + playerCamera.fieldOfView;
        }
    }

    private void RaycastsDraw()
    {
        Debug.DrawRay(transform.position, transform.right * wallJumpDetectionRange, WallRay);
        Debug.DrawRay(transform.position, -transform.right * wallJumpDetectionRange, WallRay);
        Debug.DrawRay(transform.position, transform.forward * wallJumpDetectionRange, WallRay);
        Debug.DrawRay(transform.position, -transform.forward * wallJumpDetectionRange, WallRay);
        Debug.DrawRay(transform.position, -transform.up * controller.height * CharaControlHeightExtend, GroundedRay);
    }

    private bool WallRayCasts()
    {
        return Physics.Raycast(transform.position, transform.right, wallJumpDetectionRange, wallLayer) ||
        Physics.Raycast(transform.position, -transform.right, wallJumpDetectionRange, wallLayer) ||
        Physics.Raycast(transform.position, transform.forward, wallJumpDetectionRange, wallLayer) ||
        Physics.Raycast(transform.position, -transform.forward, wallJumpDetectionRange, wallLayer);
    }   

    private void textDebug()
    {
        if(isRayGrounded)
        {
            Debug.Log("Player Is Grounded by Raycast");
        }

        if (WallRayCasts())
        {
            Debug.Log("Colliding Wall");
        }
    }
}
