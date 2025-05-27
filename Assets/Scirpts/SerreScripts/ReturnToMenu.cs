using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTrigger : MonoBehaviour
{

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
