using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPart1Jetpack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        Debug.Log("Entered trigger");
        if (other.CompareTag("Player")){
            SceneManager.LoadScene("JetpackScene2");
        }
    }
}
