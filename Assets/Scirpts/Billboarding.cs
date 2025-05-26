using UnityEngine;

public class Billboarding : MonoBehaviour
{
    public Transform cam;

    Quaternion OriginalRotation;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
