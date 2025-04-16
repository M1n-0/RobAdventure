using UnityEngine;

public class Flying : MonoBehaviour
{
    [Header("Player Movement details")]
    public float speed = 10f;
    public Rigidbody Rigidbody;

    public GameObject GameOverMenu;

    void Start(){
        Time.timeScale = 1;
    }
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Entered trigger");
        if (other.CompareTag("Obstacle")){
            GameOverMenu.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
}
