using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveBalaAngle : BalaMove
{
    [SerializeField]

    private float launchAngle = 45f;

    protected override void Mover()
    {
        float launchAngleradians = launchAngle * Mathf.Deg2Rad;
        Vector2 launchVelocity = new Vector2(Mathf.Cos(launchAngleradians) * speed, Mathf.Sin(launchAngleradians) * speed);

        rb.velocity = launchVelocity;
    }

}
