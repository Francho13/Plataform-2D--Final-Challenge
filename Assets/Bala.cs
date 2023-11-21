using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private float tiempoTranscurrido = 0f; // Agrega esta variable

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= 5f)
        {
            gameObject.SetActive(false);
            tiempoTranscurrido = 0f;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<CombateJugador>().TomarDaño(10, other.GetContact(0).normal);
            gameObject.SetActive(false);
            


        }
    }
}
