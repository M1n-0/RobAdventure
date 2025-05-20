using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void LaunchRob(){
        SceneManager.LoadScene("MainMenu");
    }

    public void LaunchTestMap(){
        SceneManager.LoadScene("TestScene");
    }

    public void LaunchLightWeightTestMap(){
        SceneManager.LoadScene("TestSceneLightWeight");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Serre-Assets");
    }
}
