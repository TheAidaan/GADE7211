using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : NPC
{
    float _moveSpeed = 10f;

  
    void Start()
    {
        AssignAttributes("Triangle", "TRIANGLE01",0.1f);
    }

    private void FixedUpdate()
    {
        if (transform.position.x > -30f)
        {
            movementDir.x = -1f;
        }
        else
        {
            movementDir = Vector2.zero;
        } 

        if (rb.velocity != Vector2.zero)
        {
            AnimateWalking(true);
        }
        else
        {
            AnimateWalking(false);
        }

        rb.velocity = movementDir.normalized * _moveSpeed;
    }
}
