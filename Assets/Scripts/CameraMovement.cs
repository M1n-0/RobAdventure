using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject Player;

    void Update()
    {
        transform.position = new Vector3(gameObject.transform.position.x,Player.transform.position.y + 2f,gameObject.transform.position.z);
    }
}
