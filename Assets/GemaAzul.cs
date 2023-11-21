using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemaAzul : MonoBehaviour
{
    [SerializeField] private GameObject efecto;
    [SerializeField] private Puntaje puntaje;
    [SerializeField] private AudioClip gemcolected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puntaje.SumarPuntos(1); // Aumenta el puntaje en 1 unidad
            Instantiate(efecto, transform.position, Quaternion.identity);
            ControladorSonido.Instance.EjecutarSonido(gemcolected);
            Destroy(gameObject);
            
        }
    }
}