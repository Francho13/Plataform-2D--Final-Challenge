using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion : MonoBehaviour
{
    [SerializeField] AudioClip curar;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<CombateJugador>().Curar(20);
            ControladorSonido.Instance.EjecutarSonido(curar);
            Destroy(gameObject);
        }
    }
}
