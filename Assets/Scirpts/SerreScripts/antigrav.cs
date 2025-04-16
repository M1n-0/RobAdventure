using UnityEngine;
using static batterie;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class antigrav : MonoBehaviour
{
    PlayerMovementSerre move;
    public GameObject rob;
    public GameObject antigravleaf;
    public Canvas canvas;
    public Canvas menu;
    public GameObject zone;
    public int battery = 0;
    public TMP_Text text;
    public float ztrans = -5f; // Default value

    void Start()
    {
        move = GetComponent<PlayerMovementSerre>();
    }
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
            SceneManager.LoadScene("JetpackScene1");
        }
    }

}