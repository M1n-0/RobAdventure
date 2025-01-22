using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class location_lauch : MonoBehaviour
{
    GameObject newTriggerObject;
    Rigidbody m_Rigidbody;
    public GameObject shadow;
    private GameObject previousShadow;

    public GameObject levier;
    private bool isinzone = false;
    private int ventilo = 1;
    private bool lockpos = false;
    private int levierstatus = 0;
    private bool onlevier = false;
    public GameObject tv;
    private GameObject previoustv;


    void OnTriggerEnter(Collider triggerObject)
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        if (triggerObject.name == "Zone")
    {
        isinzone = true;
    } else if (triggerObject.name != "Zone")
    {
        isinzone = false;
    }
    }
    void Update(){
        if (isinzone == true) {
            if (Input.GetKeyDown(KeyCode.LeftControl) && onlevier == false) {
                m_Rigidbody.constraints = RigidbodyConstraints.None;
                if (previousShadow != null){
                    Destroy(previousShadow);
                }
                lockpos = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && lockpos == false){
                m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                hover();
                lockpos = true;
            }
            if (lockpos == true && onlevier == false) {
                ventilselect();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && onlevier == false && lockpos == true) {
                    onlevier = true;
                }
            if (onlevier == true){
                levierrotation();
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) && onlevier == true) {
                onlevier = false;
            }
        }
    }
    void levierrotation(){
        if (Input.GetKeyDown(KeyCode.RightArrow) && levierstatus == 0) {
            if (previoustv != null){
                    Destroy(previoustv);
                }
            levier.transform.Rotate(0.0f, 0.0f, -45.0f, Space.Self);
            previoustv = Instantiate(tv, new Vector3(6.61f,2.86f,8.74f), Quaternion.identity);
            previoustv.transform.Rotate(-100.0f, 20.0f, 0.0f, Space.Self);
            previoustv.GetComponent<Renderer>().material.color = Color.blue;
            levierstatus = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && levierstatus == -1) {
            if (previoustv != null){
                    Destroy(previoustv);
                }
            levier.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
            previoustv = Instantiate(tv, new Vector3(6.61f,2.86f,8.74f), Quaternion.identity);
            previoustv.transform.Rotate(-100.0f, 20.0f, 0.0f, Space.Self);
            levierstatus = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && levierstatus == 1) {
            if (previoustv != null){
                    Destroy(previoustv);
                }
            levier.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
            previoustv = Instantiate(tv, new Vector3(6.61f,2.86f,8.74f), Quaternion.identity);
            previoustv.transform.Rotate(-100.0f, 20.0f, 0.0f, Space.Self);
            levierstatus = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && levierstatus == 1) {
            if (previoustv != null){
                    Destroy(previoustv);
                }
            levier.transform.Rotate(0.0f, 0.0f, 45.0f, Space.Self);
            previoustv = Instantiate(tv, new Vector3(6.61f,2.86f,8.74f), Quaternion.identity);
            previoustv.transform.Rotate(-100.0f, 20.0f, 0.0f, Space.Self);
            previoustv.GetComponent<Renderer>().material.color = Color.red;
            levierstatus = -1;
        }
    }
    void hover(){
        if (previousShadow != null)
        {
            Destroy(previousShadow);
        }
        switch(ventilo){
            case 1:
                previousShadow = Instantiate(shadow, new Vector3(0f,2.5f,10.1f), Quaternion.identity);
                break;
            case 2:
                previousShadow = Instantiate(shadow, new Vector3(1.5f,2.5f,10.1f), Quaternion.identity);
                break;
            case 3:
                previousShadow = Instantiate(shadow, new Vector3(3f,2.5f,10.1f), Quaternion.identity);
                break;
            case 4:
                previousShadow = Instantiate(shadow, new Vector3(0f,1f,10.1f), Quaternion.identity);
                break;
            case 5:
                previousShadow = Instantiate(shadow, new Vector3(1.5f,1f,10.1f), Quaternion.identity);
                break;
            case 6:
                previousShadow = Instantiate(shadow, new Vector3(3f,1f,10.1f), Quaternion.identity);
                break;
        }
    }
    void ventilselect(){
        if (isinzone == true) {
            if (Input.GetKeyDown(KeyCode.UpArrow) && ventilo > 3){
            ventilo -= 3;
            hover();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) && 6 > ventilo && ventilo > 3){
                ventilo -= 2;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && ventilo != 3 && ventilo != 6){
                ventilo += 1;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && ventilo < 3){
                ventilo += 4;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && ventilo < 4){
                ventilo += 3;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && 1 < ventilo && ventilo < 4){
                ventilo += 2;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && ventilo != 1 && ventilo != 4){
                ventilo -= 1;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && ventilo > 4){
                ventilo -= 4;
                hover();
            }
        }
    }
}
