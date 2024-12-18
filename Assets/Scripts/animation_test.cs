using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_test : MonoBehaviour
{
    public void anime(){
        // Move object
        transform.position = new Vector3(-10, transform.position.y, -10);
    }
}
