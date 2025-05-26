using UnityEngine;


public class Animations : MonoBehaviour
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
        if (Input.GetKey(KeyCode.Space))
        {
            animate.SetBool("isJumping",true);
        }
        else
        {
            animate.SetBool("isJumping",false);
        }
    }

}