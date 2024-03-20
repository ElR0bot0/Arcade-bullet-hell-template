using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Testing");//cambiar esto despues a "Level 1"
    }
    public void Settings()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
