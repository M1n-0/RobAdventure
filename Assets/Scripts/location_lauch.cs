using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class location_lauch : MonoBehaviour
{
    GameObject newTriggerObject;
    Rigidbody m_Rigidbody;

    void OnTriggerEnter(Collider triggerObject)
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        if (triggerObject.name == "Zone")
    {
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        Debug.Log("Animation Launched");
        GameObject.Find("decor").GetComponent<animation_test>().anime();

    }
    }
}
