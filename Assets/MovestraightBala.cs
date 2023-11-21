using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovestraightBala : BalaMove
{
    protected override void Mover()
    {

        Vector2 direction = Vector2.left;
        rb.velocity = direction * speed;
    }


}
