using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Animator doorAnimator;
    public Transform player;
    public float interactionDistance = 5f;
    private bool hasOpened = false; // To ensure it plays only once

    void Start()
    {
        doorAnimator.enabled = false; // Disable Animator at start
    }

    void Update()
    {
        if (!hasOpened && Vector3.Distance(transform.position, player.position) < interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                doorAnimator.enabled = true; // Enable Animator when the button is pressed
                doorAnimator.SetTrigger("OpenDoor");
                hasOpened = true;
            }
        }
    }

}
