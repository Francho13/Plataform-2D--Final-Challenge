using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private CombateJugador combateJugador;
    [SerializeField] private GameObject BarradeVida;

    private void Start()
    {
        combateJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<CombateJugador>();
        combateJugador.MuerteJugador += ActivarMenu;
    }
    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
        Time.timeScale = 0f; // Pausa el tiempo en el juego
        BarradeVida.SetActive(false);
        
    }

    public void Reiniciar()
    {

        Time.timeScale = 1f; // Reanuda el tiempo en el juego
        Physics2D.IgnoreLayerCollision(6, 7, false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Salir()
    {
        
        Application.Quit();
    }
}


