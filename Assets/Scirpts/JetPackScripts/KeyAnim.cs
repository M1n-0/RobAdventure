using UnityEngine;
using static KeyTrigger;

public class KeyAnim : MonoBehaviour
{
    public int up;
    public int down;
    public int rotateSpeed;
    private float move;

    void Start()
    {
        move = up/10;
    }

    void Update()
    {
        if (keyCollected){
            transform.position += new Vector3(0, move - 0.01f, 0) * 10 * Time.deltaTime;
            up -= 1;
            if (up <= down){
                Destroy(gameObject);
            }
            move = up/10;
        }
        else{
            float angle = rotateSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.AngleAxis(angle, new Vector3(-1, 0, -1));
        }
    }
}
