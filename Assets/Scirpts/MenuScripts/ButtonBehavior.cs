using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public Button selectedOnAwakeButton;

    private void Awake()
    {
        selectedOnAwakeButton.Select();
    }

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
        SceneManager.LoadScene("JetpackScene1");
    }
}
