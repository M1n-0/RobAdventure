using UnityEngine;


public class walk : MonoBehaviour
{
    Animator animate;
    
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        

        Vector3 moveDirection = new Vector3(horizontalInput, 0, 0).normalized;

        if (moveDirection != Vector3.zero)
        {
            animate.SetBool("isWalking",true);
        }
        else
        {
            animate.SetBool("isWalking",false);
        }
    }

}