using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float scrollSpeed;
 
    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
    }
}