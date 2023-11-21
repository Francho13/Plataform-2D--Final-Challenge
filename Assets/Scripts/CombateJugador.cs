using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using System;

public class CombateJugador : MonoBehaviour
{
    [Header("Barra de Vida")]

    [SerializeField] private float vida;

    [SerializeField] private float maximoVida;

    [SerializeField] private BarraVida barraDeVida;

    [Header("Colision")]

    private MovimientoHeroe movimientoHeroe;

    [SerializeField] private float tiempoPerdidaControl;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip colision;

    public event EventHandler MuerteJugador;

    private Rigidbody2D rb2D;

    private Animator animator;

   

    private void Start()

    {
        movimientoHeroe = GetComponent <MovimientoHeroe>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent <Rigidbody2D>();
        vida = maximoVida;
        barraDeVida.InicializarBarraDeVida(vida);

    }



    public void TomarDaño(float daño , Vector2 posicion)
    {
       

        vida -= daño;
        ControladorSonido.Instance.EjecutarSonido(colision);
        barraDeVida.CambiarVidaActual(vida);

        if (vida <= 0)
        {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            audioSource.Stop();
            Destroy(gameObject);
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        animator.SetTrigger("Impacto");
        StartCoroutine(PerderControl());
        StartCoroutine(DesactivarColision());
        movimientoHeroe.Rebote(posicion);
    }

    public IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(6,7,true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    public IEnumerator PerderControl()
    {
        movimientoHeroe.sepuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoHeroe.sepuedeMover = true;
    }

    public void Curar(float curacion)
    {
        if((vida + curacion) > maximoVida)
        {
            vida = maximoVida;
            barraDeVida.CambiarVidaActual(vida);

        }
        else
        {
            vida += curacion;
            barraDeVida.CambiarVidaActual(vida);
        }
    }

    
}

