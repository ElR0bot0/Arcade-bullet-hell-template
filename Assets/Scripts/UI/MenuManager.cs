using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [Header("MenuObjects")]
    public GameObject pauseMenu;
    public GameObject EndLevelMenu;
    public GameObject BotonReintentar;
    public GameObject BotonContinuar;
    public TextMeshProUGUI Mensaje;

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

    public void Continue()
    {
        Resume();
        Debug.Log("Cambiar esto cuando haya mas niveles");
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndLevel()
    {
        Time.timeScale = 0f;
        EndLevelMenu.SetActive(true);
    }

    public void DeadScreen()
    {
        BotonContinuar.SetActive(false);
        var PosicionBotonReintentar = BotonReintentar.GetComponent<RectTransform>();
        Vector2 anchoredPosicionBotonReintentar = PosicionBotonReintentar.anchoredPosition;
        anchoredPosicionBotonReintentar.x = 0f;
        PosicionBotonReintentar.anchoredPosition = anchoredPosicionBotonReintentar;
        Mensaje.text = "Mejor suerte a la proxima!";
        EndLevel();
    }
    
}
