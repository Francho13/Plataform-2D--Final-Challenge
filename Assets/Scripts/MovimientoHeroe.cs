using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class MovimientoHeroe : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public bool sepuedeMover = true;

    [SerializeField] private Vector2 velocidadRebote;


    [Header("Movimiento")]

    private float movimientoHorizontal = 0f;

    [SerializeField] private float velocidadMovimiento;

    [SerializeField] private float suavizadorMovimiento;

    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true;

    [Header("Salto")]

    [SerializeField] private float fuerzaSalto;

    [SerializeField] private LayerMask queesSuelo;

    [SerializeField] private Transform controladorSuelo;

    [SerializeField] private Vector3 dimensionesCaja;

    [SerializeField] private bool enSuelo;

    private bool salto = false;

    [Header("Doble Salto")]

    [SerializeField] private int saltosExtrasRestantes;
    [SerializeField] private int saltosExtra;
    [SerializeField] public GameObject habilidadunlocked1;



    [Header("Animacion")]

    private Animator animator;


    [Header("Efecto salto")]

    [SerializeField] private AudioClip jumping;

    [Header("Particulas")]
    [SerializeField] private ParticleSystem particle;

    [Header("Dash")]
    [SerializeField] private float velocidadDash;
    [SerializeField] private float tiempoDash;
    //[SerializeField] private TrailRenderer trailRenderer;
    private float gravedadInicial;
    private bool puedeHacerDash = true;
    private bool sePuedeMover = true;
    [SerializeField] public GameObject habilidadunlocked2;

    private Progresion progresion;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gravedadInicial = rb2D.gravityScale;

        progresion = GetComponent<Progresion>();

    }

    private void Update()
    {

        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        if(enSuelo)
        {
            saltosExtrasRestantes = saltosExtra;
        }

        if (Input.GetButtonDown("Jump"))
        {
            particle.Play();
            salto = true;
            
        }


    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queesSuelo);
        animator.SetBool("enSuelo", enSuelo);
       


        if (sepuedeMover)
        {
            Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);
        }

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
        if(progresion.PerfilHeroe.CurrentLevel1>= 2)
        {
            StartCoroutine(MensajeDesbloqueado2());
        }
        if (Input.GetKeyDown(KeyCode.B) && puedeHacerDash & progresion.PerfilHeroe.CurrentLevel1 >= 2)
        {
            
            StartCoroutine(Dash());
            
        }

        salto = false;

        
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadorMovimiento);

        if(mover > 0 && !mirandoDerecha)
        {
            Girar();

        }else if(mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        if(enSuelo && saltar)
        {
            Salto();
        }
        else
        {
            if(progresion.PerfilHeroe.CurrentLevel1 >= 1)
            {
                StartCoroutine(MensajeDesbloqueado());
            }
            if(salto && saltosExtrasRestantes > 0 & progresion.PerfilHeroe.CurrentLevel1 >= 1)
            {
                
                Salto();
                saltosExtrasRestantes -= 1;
                
            }
        }
        
    }

    private void Salto ()
    {
        enSuelo = false;

        ControladorSonido.Instance.EjecutarSonido(jumping);
        rb2D.AddForce(new Vector2(0f, fuerzaSalto));

        particle.Play();
    }

    private IEnumerator Dash()
    {
        sePuedeMover = false;
        puedeHacerDash = false;
        rb2D.gravityScale = 0;
        rb2D.velocity = new Vector2(velocidadDash * transform.localScale.x, 0);
        //animator.SetTrigger("Dash");
        //trailRenderer.emitting = true;

        yield return new WaitForSeconds(tiempoDash);

        sePuedeMover = true;
        puedeHacerDash = true;
        rb2D.gravityScale = gravedadInicial;
        //trailRenderer.emitting = false;
    }

    private IEnumerator MensajeDesbloqueado()
    {
        habilidadunlocked1.SetActive(true);
        yield return new WaitForSeconds(1);
    }
    private IEnumerator MensajeDesbloqueado2()
    {
        habilidadunlocked2.SetActive(true);
        yield return new WaitForSeconds(1);
    }


    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
        if(enSuelo)
        {
            particle.Play();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }

    public void Rebote(Vector2 puntodeGolpe)
    {
        rb2D.velocity = new Vector2(-velocidadRebote.x * puntodeGolpe.x, velocidadRebote.y);
    }

   
}


