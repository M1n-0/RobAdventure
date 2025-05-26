using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public float interval;
    public float range;
    private float timer = 0f;

    void Start()
    {
        
    } 

    void Update()
    {
        timer += Time.deltaTime;
        RaycastHit hit;
        Ray shootingRay = new Ray(transform.position, new Vector3(-1, 0, 0));
        if (Physics.Raycast(shootingRay, out hit, range) && (timer >= interval))
        {
            if (hit.collider.tag == "Player")
            {
                GameObject laser = Instantiate(projectile);
                laser.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                timer = 0f;
            }
        }
    }
}
