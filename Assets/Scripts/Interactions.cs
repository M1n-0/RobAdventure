using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class interraction : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public Material yourMaterial;
    public Material otherMaterial;
    public Material thirdMaterial;
    public GameObject Cube;
    private bool isIn = false;
    public GameObject shadow;
    private GameObject previousShadow;
    private int ventilo = 1;
    public static bool lockpos = false;
    public static bool lockvent = false;
    private int screen = 0;
    public GameObject levier;
    private void OnTriggerEnter(Collider other){
        m_Rigidbody = GetComponent<Rigidbody>();
        Debug.Log("Entered trigger");
        if (other.CompareTag("Zone")){
            isIn = true;
            Debug.Log("Is in");
        }
    }
    private void OnTriggerExit(Collider other){
        Debug.Log("Exited Trigger"); 
        if (other.CompareTag("Zone")){
            isIn = false;
        }
    }
    void Update(){

        if (isIn) {

            if (Input.GetKeyDown(KeyCode.LeftControl) && lockpos == true && lockvent == false) {
                m_Rigidbody.constraints = RigidbodyConstraints.None;
                if (previousShadow != null){
                    Destroy(previousShadow);
                }
                lockpos = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && lockpos == false && lockvent == false) {
                m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                hover();
                Debug.Log("lock");
                lockpos = true;
            }
            if (lockpos == true && lockvent == false){ 
                ventilselect();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && lockpos == true && lockvent == false) {
                lockvent = true;
            }
            if (lockpos == true && lockvent == true){
                changescreen();
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) && lockpos == true && lockvent == true) {
                lockvent = false;
                if (screen == 1){
                    screen = 0;
                    levier.transform.Rotate(0.0f, 0.0f, 45.0f);
                }
                if (screen == -1){
                    screen = 0;
                    levier.transform.Rotate(0.0f, 0.0f, -45.0f);
                }
                matchange();
            }
        }
    }
    void matchange(){
        Debug.Log("azoa");
        switch(screen){
            case -1:
                Cube.GetComponent<Renderer>().material = otherMaterial;
                break;
            case 0:
                Cube.GetComponent<Renderer>().material = yourMaterial;
                break;
            case 1:
                Cube.GetComponent<Renderer>().material = thirdMaterial;
                break;
        }
    }
    void changescreen(){
        Debug.Log("screen change");
        if (isIn == true) {
            if (Input.GetKeyDown(KeyCode.RightArrow ) && screen < 1){
                screen += 1;
                levier.transform.Rotate(0.0f, 0.0f, -45.0f, Space.Self);
                matchange();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && screen > -1){
                screen -= 1;
                levier.transform.Rotate(0.0f, 0.0f, 45.0f, Space.Self);
                matchange();
            }
        }
    }
    void hover(){
        if (previousShadow != null)
        {
            Destroy(previousShadow);
        }
        switch(ventilo){
            case 1:
                previousShadow = Instantiate(shadow, new Vector3(0.042f,-0.02f,0.01f), Quaternion.identity);
                previousShadow.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                break;
            case 2:
                previousShadow = Instantiate(shadow, new Vector3(0.195f,-0.02f,0.01f), Quaternion.identity);
                previousShadow.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                break;
            case 3:
                previousShadow = Instantiate(shadow, new Vector3(0.042f,0.1f,0.01f), Quaternion.identity);
                previousShadow.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                break;
            case 4:
                previousShadow = Instantiate(shadow, new Vector3(0.195f,0.1f,0.01f), Quaternion.identity);
                previousShadow.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                break;
        }
    }
    void ventilselect(){
        if (isIn == true) {
            if (Input.GetKeyDown(KeyCode.UpArrow) && ventilo < 3){
                ventilo += 2;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) && ventilo == 1){
                ventilo += 3;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && ventilo != 2 && ventilo != 4){
                ventilo += 1;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && ventilo == 3){
                ventilo -= 1;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && ventilo > 2){
                ventilo -= 2;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && ventilo == 4){
                ventilo -= 3;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && ventilo != 1 && ventilo != 3){
                ventilo -= 1;
                hover();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && ventilo == 2){
                ventilo += 1;
                hover();
            }
        }
    }}
