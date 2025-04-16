using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void reload(){
        SceneManager.LoadScene("JetpackScene1");
    }
}
