using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    public float jumpSpeed;
    private float ySpeed;
    private float horizontalInput;
    private float verticalInput;
    private CharacterController conn;
    public bool isGrounded;

    Vector3 moveDirection;
    Vector3 vel;

    private void Start()
    {
        conn = GetComponent<CharacterController>();
    }

    private void Update()
    {
        myInput();
        movePlayer();
    }

    private void myInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void movePlayer()
    {
        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection.Normalize();
        //transform.Translate(moveDirection * movementSpeed);
        conn.SimpleMove(moveDirection * movementSpeed);
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if(Input.GetButtonDown("Jump"))
        {
            ySpeed = -0.5f;
            isGrounded = false;
        }
        vel = moveDirection;
        vel.y = ySpeed;
        //transform.Translate(vel);
        conn.SimpleMove(vel);
        if(conn.isGrounded)
        {
            ySpeed = -0.5f;
            isGrounded = true;
            if(Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
                isGrounded = false;
            }

        }
    }
}
