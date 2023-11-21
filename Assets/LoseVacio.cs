using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseVacio : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {



        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<CombateJugador>().TomarDa�o(2000, other.GetContact(0).normal);



        }
    }
}

