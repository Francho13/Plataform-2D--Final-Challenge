using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class CañonSpawn : MonoBehaviour
{

    [Header("Tiempos de Spawn")]
    [SerializeField] private float tiempoMinSpawn;
    [SerializeField] private float tiempoMaxSpawn;

    private bool seguirSpawneando = true;

    [SerializeField] private float tiempoEspera = 1f;

    [SerializeField] private Transform punto;

    [Header("Spawer dectectado")]
    public Camera mainCamera;

    [Header("Efecto Spawn")]
    private AudioSource audioSource;

    // Añade esta variable para la referencia al BalaPool
    [SerializeField] private BalaPool objectpool;


    private void Awake()
    {
        objectpool = GetComponent<BalaPool>();
    }
    private void Start()
    {
        mainCamera = Camera.main;
        audioSource = GetComponent<AudioSource>();

        // Comenzar la corrutina de spawn de enemigos
        StartCoroutine(SpawnEnemigos());
    }

    private IEnumerator SpawnEnemigos()
    {
        while (seguirSpawneando)
        {
            // Verificar si el spawner está en la vista de la cámara
            if (EstaEnVistaDeCamara())
            {
                // Obtener una bala del BalaPool en lugar de instanciar una nueva
                GameObject objectpooled = objectpool.GetPooledObject();

                if (objectpooled != null)
                {
                    objectpooled.transform.position = punto.position;
                    objectpooled.transform.rotation = Quaternion.identity;
                    objectpooled.SetActive(true);
                    audioSource.Play();
                }
            }
            float tiempoEspera = Random.Range(tiempoMinSpawn, tiempoMaxSpawn);
            yield return new WaitForSeconds(tiempoEspera);

        }
        
    }

    private bool EstaEnVistaDeCamara()
    {
        if (mainCamera == null) return false;

        // Verificar si el spawner está dentro de la vista de la cámara
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);
        return (viewportPos.x >= 0 && viewportPos.x <= 1 && viewportPos.y >= 0 && viewportPos.y <= 1);
    }

    // Método para detener el spawner
    public void DetenerSpawner()
    {
        seguirSpawneando = false;
    }
}
