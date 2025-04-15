using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeMenu : MonoBehaviour
{
    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }
}
