using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    [SerializeField] Transform CameraPosition;
    [SerializeField] Vector3 NewCameraPosition;
    [SerializeField] float LerpForce;
    PlayerMovement Player;

    

    void LateUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, CameraPosition.position - NewCameraPosition, Time.deltaTime * LerpForce);
    }
}
