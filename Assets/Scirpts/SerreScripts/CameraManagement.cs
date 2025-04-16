using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    [SerializeField] Transform CameraPosition;
    [SerializeField] Vector3 NewCameraPosition;
    [SerializeField] float LeafMultiplicator;
    [SerializeField] float LerpForce;
    public PlayerMovementSerre move;


    void LateUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, CameraPosition.position - NewCameraPosition, Time.deltaTime * LerpForce);
        if(move.hasLeaf)
        {
           transform.position = Vector3.Slerp(transform.position, CameraPosition.position - NewCameraPosition * LeafMultiplicator, Time.deltaTime * LerpForce);
        }
    }
}
