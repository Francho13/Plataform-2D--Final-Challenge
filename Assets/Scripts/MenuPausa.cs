using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject pausaMenu; // Referencia al menú de pausa en el Inspector

    [SerializeField] private AudioSource audioSource;
    

    private bool isPaused = false;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Pausa el tiempo en el juego
        audioSource.Pause();
        pausaMenu.SetActive(true); // Activa el menú de pausa
        isPaused = true;
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Reanuda el tiempo en el juego
        audioSource.UnPause();
        pausaMenu.SetActive(false); // Desactiva el menú de pausa
        isPaused = false;
        
    }



    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Cerrar()
    {
        Debug.Log("Cerrando Juego");
        Application.Quit();
    }
}

