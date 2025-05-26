using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void GoToSerre()
    {
        SceneManager.LoadScene("Serre-Assets");
    }
}
