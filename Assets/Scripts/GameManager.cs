using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Gemas en el Nivel")]
    [SerializeField] private int cantidadGemas;
    [SerializeField] private int gemasObtenidas;

    [SerializeField] private AudioSource audioSource;

    [Header("Animacion")]
    private Animator animator;

    [Header("Puntaje")]
    public TextMeshProUGUI puntajeText;

    [SerializeField] public GameObject PuntajeGemaverde;
    [SerializeField] public GameObject mensajeobjetivo;



    private void Start()
    {
        animator = GetComponent<Animator>();
        cantidadGemas = GameObject.FindGameObjectsWithTag("GemaVerde").Length;
        ActualizarPuntaje();
    }

    private void ActivarPortal()
    {
        animator.SetTrigger("Activar");
    }

    public void GemasObtenidas()
    {
        gemasObtenidas += 1;
       

        if (gemasObtenidas == cantidadGemas)
        {
            audioSource.Play();
            ActivarPortal();
            PuntajeGemaverde.SetActive(false);
            mensajeobjetivo.SetActive(true);
           
        }

        ActualizarPuntaje();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gemasObtenidas == cantidadGemas)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void ActualizarPuntaje()
    {
        puntajeText.text = " " + gemasObtenidas.ToString() + "/" + cantidadGemas.ToString();
    }


}
