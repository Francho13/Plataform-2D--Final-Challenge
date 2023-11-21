using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BalaMove : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;  // Velocidad de la bala en unidades por segundo

    protected Rigidbody2D rb;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected void OnEnable()
    {
        Mover();
    }


    protected abstract void Mover();
    
}
