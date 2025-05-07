using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public PlayerMovement Player;

    void Update()
    {
        if (Player.Alive()){
            transform.position = new Vector3(gameObject.transform.position.x,Player.transform.position.y + 2f,gameObject.transform.position.z);
        }
    }
}
