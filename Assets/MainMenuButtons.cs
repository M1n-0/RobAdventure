using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void StartRobAdventure()
    {
        SceneManager.LoadScene(2);
    }

    public void StartTestMap()
    {
        SceneManager.LoadScene("");
    }

    public void StartLightWeightTestMap()
    {
        SceneManager.LoadScene("");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
