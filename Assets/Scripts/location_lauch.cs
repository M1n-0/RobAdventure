using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class location_lauch : MonoBehaviour
{
    GameObject newTriggerObject;
    Rigidbody m_Rigidbody;
    public GameObject Sphere;
    public bool isinzone = false;

    void OnTriggerEnter(Collider triggerObject)
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Debug.Log(triggerObject.name);
        if (triggerObject.name == "Zone")
    {
        Instantiate(Sphere, new Vector3(10,1,5), Quaternion.identity);
        isinzone = true;
    } else if (triggerObject.name != "Zone")
    {
        Debug.Log("Exit");
        isinzone = false;
    }
    }
    void Update(){
        Debug.Log(isinzone);
        if (isinzone == true) {
            if (Input.GetButtonDown("Fire1")){
                Debug.Log("Exit");
                m_Rigidbody.constraints = RigidbodyConstraints.None;
            }
            if (Input.GetButtonDown ("Fire2")){
                Debug.Log("Enter");
                m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                Debug.Log("Animation Launched");
                GameObject.Find("decor").GetComponent<animation_test>().anime();
            }
        }
    }

}
