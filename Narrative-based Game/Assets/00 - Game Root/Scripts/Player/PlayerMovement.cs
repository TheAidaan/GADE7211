using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float _moveSpeed = 3;
    Rigidbody2D _rb;

    Vector2 _movementDir;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {   
        if (_movementDir != Vector2.zero) // don't face one way as a standard
        {
            transform.right = _movementDir.normalized; // always face the direction the charater is moving 
        }

        _rb.velocity = _movementDir.normalized * _moveSpeed; // move in the direction the player wants at a set speed
    }

    void Update()
    {
        _movementDir = Vector2.zero; //zero out so that if player isnt pushing a button the stop.

        if (!DialogueManager.activeDialogue) // while nobody is speaking 
        {
            if (Input.GetKey(KeyCode.W))
            {
                _movementDir.y += 1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                _movementDir.x -= 1f;
                

            }
            if (Input.GetKey(KeyCode.S))
            {
                _movementDir.y -= 1f;


            }
            if (Input.GetKey(KeyCode.D))
            {
                _movementDir.x += 1f;
            }
        }
    }
}
