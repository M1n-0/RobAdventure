using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Management : MonoBehaviour
{
    public void Ending(){
        SceneManager.LoadScene("Transition");
    }

    public void goToIntroLevel(){
        SceneManager.LoadScene("Level Intro");
    }

    public void goToMap(){
        SceneManager.LoadScene("ComingSoon");
    }

    public void CloseGame()
    {
        // Quit the game
        Application.Quit();
    }
}
