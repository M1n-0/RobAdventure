//made by NepNath 
//Creation Date: 27/11/2024
//last edited: 18/12/2024

// This script is made for a student project called "RobAdventure".
// These inputs are designed for a specific set of controller handmade,
// based on a arcade machine (arcade joystick and 4 buttons)


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement details")]
    public float speed = 10f;
    public float ascendSpeed = 5f; // Speed of ascending while holding jump
    public float turnSpeed = 10f;
    public Rigidbody Rigidbody;
    
    private bool isGrounded;
    
    [Header("Raycast properties")]
    public float maxRayDist = 1.2f; // Slightly increased for better ground detection
    public string groundTag = "JumpTrigger";

    void Start()
    {
        if (Rigidbody == null)
        {
            Rigidbody = GetComponent<Rigidbody>(); // Auto-assign Rigidbody if not set
        }
    }

    void Update()
    {   
        // Raycast for ground detection
        Vector3 rayOrigin = transform.position;
        Ray ray = new Ray(rayOrigin, Vector3.down);
        Debug.DrawLine(rayOrigin, rayOrigin + Vector3.down * maxRayDist, Color.blue);

        // Basic movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, 0).normalized;

        if (moveDirection != Vector3.zero)
        {
            transform.position += moveDirection * speed * Time.deltaTime;

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        // Jetpack effect: Player ascends while holding the jump button
        if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space)) // Gamepad & keyboard
        {
            Rigidbody.AddForce(Vector3.up * ascendSpeed, ForceMode.Acceleration);
            Debug.Log("Jetpack active");
        }

        // Ground detection using Raycast
        if (Physics.Raycast(ray, out RaycastHit hit, maxRayDist))
        {
            if (hit.collider.CompareTag(groundTag))
            {
                isGrounded = true;
                Debug.DrawLine(rayOrigin, rayOrigin + Vector3.down * maxRayDist, Color.green);
            }
        }
        else
        {
            isGrounded = false;
            Debug.DrawLine(rayOrigin, rayOrigin + Vector3.down * maxRayDist, Color.red);
        }
    }
}
