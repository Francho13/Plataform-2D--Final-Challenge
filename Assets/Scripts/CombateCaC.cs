using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class CombateCaC : MonoBehaviour
{
    [Header("Ataque")]
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;

    [Header("Efecto de Sonido")]
    [SerializeField] private AudioClip swordimpact;

    [Header("Animacion")]
    private Animator animator;
   

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.X) && tiempoSiguienteAtaque <= 0)
        {

            ControladorSonido.Instance.EjecutarSonido(swordimpact);
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("Golpe");
        

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            IDaño objeto = colisionador.GetComponent<IDaño>();

            if (objeto != null) { objeto.TomarDaño(dañoGolpe); }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
