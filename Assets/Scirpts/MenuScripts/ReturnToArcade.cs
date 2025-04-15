using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnToArcade : MonoBehaviour
{
    public void GTFO(){
        SceneManager.LoadScene("ArcadeMenu");
    }

    void Update()
    {
        if(Input.GetKeyDown("k")){
            SceneManager.LoadScene("ArcadeMenu");
        }
    }
}
