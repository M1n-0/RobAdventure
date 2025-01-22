using UnityEngine;


public class walk : MonoBehaviour
{
    Animator animation;
    
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        

        Vector3 moveDirection = new Vector3(horizontalInput, 0, 0).normalized;

        if (moveDirection != Vector3.zero)
        {
            animation.SetBool("isWalking",true);
        }
        else
        {
            animation.SetBool("isWalking",false);
        }
    }

}