using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesManager : MonoBehaviour
{
    public void JetpackP1(){
        SceneManager.LoadScene("JetpackScene1");
    }
    public void JetpackP2(){
        SceneManager.LoadScene("JetpackScene2");
    }
    public void Serre(){
        SceneManager.LoadScene("Serre-Assets");
    }
    public void Menu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}