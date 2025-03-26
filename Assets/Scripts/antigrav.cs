using UnityEngine;
using static batterie;
using UnityEngine.UI;
using TMPro;

public class antigrav : MonoBehaviour
{
    public GameObject rob;
    public GameObject antigravleaf;
    public Canvas canvas;
    public Canvas menu;
    public GameObject zone;
    public int battery = 0;
    public TMP_Text text;
    public float ztrans = -0.7f; // Default value

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger");
        if (other.CompareTag("Zone"))
        {
            Debug.Log("Is in");
            canvas.enabled = !canvas.enabled;
        }
        if (other.CompareTag("batterie"))
        {
            battery++;
            Debug.Log("battery count: " + battery);
            text.text = battery.ToString();
        }
        if (other.CompareTag("platform"))
        {
            Debug.Log("Entered trigger platform");
            ztrans = -0.7f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited Trigger");
        if (other.CompareTag("Zone"))
        {
            canvas.enabled = !canvas.enabled;
            Debug.Log("Is out");
        }
        if (other.CompareTag("platform"))
        {
            ztrans = -2f;
            Debug.Log("Is out, ztrans set to " + ztrans);
        }
        if (other.CompareTag("exit"))
        {
            menu.enabled = true; // Show the canvas when exiting the object
            Debug.Log("Exited exit object, canvas enabled");
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftControl) && canvas.enabled == true)
        {
            rob.GetComponent<ConstantForce>().force = new Vector3(0f, -0.1f, 0f);
            Destroy(antigravleaf);
            Destroy(zone);
            canvas.enabled = !canvas.enabled;
        }
    }
}