using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSnake : MonoBehaviour, IDa�o
{
    [Header("Barra de Vida Enemigo 2")]

    [SerializeField] private BarraVidaEnemigo enemigolife;
    [SerializeField] private float vida;
    [SerializeField] private float vidaMaxima;
    private Animator animator;

    [Header("Experiencia")]
    public int experienceValue;

    [Header("Partiulcas de Explosion")]

    public GameObject explosionPrefab;

    [Header("Efecto de Sonido")]
    [SerializeField] private AudioClip impact;


    private void Start()
    {

        animator = GetComponent<Animator>();
        vida = vidaMaxima;
        enemigolife.UpdateBarradeVida(vidaMaxima, vida);

    }
    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        enemigolife.UpdateBarradeVida(vidaMaxima, vida);


        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        if (vida <= 0)
        {

            Muerte();
           

        }
    }
    public void Muerte()
    {

        ControladorSonido.Instance.EjecutarSonido(impact);
        Destroy(gameObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Progresion Progresion = player.GetComponent<Progresion>();
        Progresion.GainExperience(experienceValue);

    }
}
