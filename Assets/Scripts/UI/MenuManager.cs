using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void DesplegarMenuOpciones()
    {
        Debug.Log("Cargando menu.....");
    }
    public void CargarMenuPrincipal()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Debug.Log("Saliendo de la aplicacion.....");
        Application.Quit();
    }
}
