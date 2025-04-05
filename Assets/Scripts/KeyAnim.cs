using UnityEngine;
using static KeyTrigger;

public class KeyAnim : MonoBehaviour
{
    public int move;
    private float realMove;

    void Start()
    {
        realMove = move/10;
    }

    void Update()
    {
        if (keyCollected){
            transform.position += new Vector3(0, realMove - 0.01f, 0)* 10 * Time.deltaTime;
            move -= 1;
            if (move <= -6){
                Destroy(gameObject);
            }
            realMove = move/10;
        }
    }
}
