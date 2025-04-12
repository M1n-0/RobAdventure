using UnityEngine;
using static KeyTrigger;

public class KeyAnim : MonoBehaviour
{
    public int up;
    public int down;
    private float move;

    void Start()
    {
        move = up/10;
    }

    void Update()
    {
        if (keyCollected){
            transform.position += new Vector3(0, move - 0.01f, 0)* 10 * Time.deltaTime;
            up -= 1;
            if (up <= down){
                Destroy(gameObject);
            }
            move = up/10;
        }
    }
}
