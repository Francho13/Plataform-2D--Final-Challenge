using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemigosconPool: MonoBehaviour
{
    [Header("Prefabs Enemigos")]

    public List<GameObject> enemigosPrefabs = new List<GameObject>();

    [Header("Tiempos de Spawn")]
    [SerializeField] private float tiempoMinSpawn;
    [SerializeField] private float tiempoMaxSpawn;
    private bool seguirSpawneando = true;

    [Header("Spawer dectectado")]
    public Camera mainCamera;

    [Header("Efecto Spawn")]
    private AudioSource audioSource;

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
                // Spawnear un enemigo aleatorio de la lista
                int indiceEnemigo = Random.Range(0, enemigosPrefabs.Count);
                GameObject enemigoPrefab = enemigosPrefabs[indiceEnemigo];
                Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
                audioSource.Play();
            }
           

            // Esperar un tiempo aleatorio entre tiempoMinSpawn y tiempoMaxSpawn segundos
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
   

