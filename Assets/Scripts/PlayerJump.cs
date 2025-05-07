using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
public float jumpForce = 15f; // Increased jump force for better height
    public Rigidbody rb; // Reference to the Rigidbody component
    public float gravityScale = 1f; // Gravity scale multiplier
    private bool isGrounded; // Check if the player is grounded
    public string groundTag = "JumpTrigger"; // Tag to identify ground

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        rb.useGravity = true; // Ensure gravity is enabled
        Physics.gravity *= gravityScale; // Adjust the gravity scale
    }

    void Update()
    {
        // Check for jump input
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("Jump executed");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = true; // Set grounded state to true
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = false; // Set grounded state to false
        }
    }
}
