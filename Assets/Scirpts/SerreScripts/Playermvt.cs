//made by NepNath 
//Creation Date: 27/11/2024
//last edited: 18/12/2024

// This script is made for a student project called "RobAdventure".
// These inputs are designed for a specific set of controller handmade,
// based on a arcade machine (arcade joystick and 4 buttons)


using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;
using static interraction;

public class PlayerMovementSerre : MonoBehaviour
{
    [Header("Player Movement details")]
    public float speed = 10f;
    public float JumpForce = 10;
    public Rigidbody Rigidbody;
    public float TurnSpeed;
    public bool hasLeaf;
    [SerializeField] float Gravity;
    [SerializeField] float LeafGravity;
    [SerializeField] float PlatformForce;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector3 groundRadiusPosition;
    public float groundRadius;
    [Header("Raycast propeties")]

    Ray ray;
    public float MaxRayDist = 100;
    public string groundTag = "JumpTrigger";
    
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
        }
        
        addedGravity();

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        Vector3 moveDirection = new Vector3(-horizontalInput, 0, 0).normalized;

        if (!lockpos) {
            if (moveDirection != Vector3.zero)
            {
                transform.position += moveDirection * speed * Time.deltaTime;
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
            }
        }
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button3) && isGrounded())
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
        else if(hasLeaf)
        {
            Rigidbody.AddForce(Vector3.down * LeafGravity, ForceMode.Force);
        }
    }

    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Apply bounce effect
            GetComponent<Rigidbody>().linearVelocity = new Vector3(0,PlatformForce, 0); // Adjust force as needed
        }
    }

}