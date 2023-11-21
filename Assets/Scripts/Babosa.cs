using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babosa : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<CombateJugador>().TomarDaño(5, other.GetContact(0).normal);
            


        }
    }
}
