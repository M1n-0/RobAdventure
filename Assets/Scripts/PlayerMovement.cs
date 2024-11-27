using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    public float jumpSpeed;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    private void Start()
    {
    
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
        transform.Translate(moveDirection * movementSpeed);
    }
}
