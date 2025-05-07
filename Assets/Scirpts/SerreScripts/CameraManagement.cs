using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    [SerializeField] Transform CameraPosition;
    [SerializeField] Transform CameraPosition2;

    [SerializeField] Vector3 NewCameraPosition;

    [SerializeField] Vector3 NewCameraPosition2;
    [SerializeField] Quaternion Cam2Rotation;
    [SerializeField] Quaternion CamRotation;

    [SerializeField] float LeafMultiplicator;
    [SerializeField] float LerpForce;
    public PlayerMovementSerre move;


    void LateUpdate()
    {
        if(!move.IsInJump)
        {
            transform.position = Vector3.Slerp(transform.position, CameraPosition.position - NewCameraPosition, Time.deltaTime * LerpForce);
            transform.rotation = Quaternion.Slerp(transform.rotation, CamRotation, Time.deltaTime * LerpForce);

        }
        if(move.hasLeaf)
        {
           transform.position = Vector3.Slerp(transform.position, CameraPosition.position - NewCameraPosition * LeafMultiplicator, Time.deltaTime * LerpForce);
        }
        if(move.IsInJump)
        {
            transform.position = Vector3.Slerp(transform.position, CameraPosition2.position - NewCameraPosition2, Time.deltaTime * LerpForce);
            transform.rotation = Quaternion.Slerp(transform.rotation, Cam2Rotation, Time.deltaTime * LerpForce);
        }
    }
}


