using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void goTonextlevel(){
        SceneManager.LoadScene("1");
    }
    public void restart(){
        SceneManager.LoadScene("dev");
    }
    public void goToMap(){
        SceneManager.LoadScene("2");
    }
    public void CloseGame()
    {
        // Quit the game
        Application.Quit();
    }
}
