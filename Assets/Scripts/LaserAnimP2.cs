using UnityEngine;

public class LaserAnimP2 : MonoBehaviour
{
    public float interval;
    private float timer = 0f;
    private bool isRotated = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            float xRotation = isRotated ? 0f : 180f;
            transform.rotation = Quaternion.Euler(xRotation, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.eulerAngles.z);
            isRotated = !isRotated;
            timer = 0f;
        }
    }
}
