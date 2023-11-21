using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemaVerde : MonoBehaviour
{
    [SerializeField] private GameObject efecto;

    [SerializeField] private AudioClip gemcolected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Instantiate(efecto, transform.position, Quaternion.identity);
            ControladorSonido.Instance.EjecutarSonido(gemcolected);
            GameObject.FindGameObjectWithTag("Portal").GetComponent<GameManager>().GemasObtenidas();
            Destroy(gameObject);
        }
    }
}
