using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float _moveSpeed = 9;
    Rigidbody2D _rb;
    PlayerAnimations _animator;

    Vector2 _movementDir;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<PlayerAnimations>();
    }

    private void FixedUpdate()
    {   
        if (_movementDir != Vector2.zero) // don't face one way as a standard
        {
            _animator.WalkingAnimation(true); //Activate the walking animation

        }else
        {
            _animator.WalkingAnimation(false); //end the walking animaation
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
                transform.right = new Vector2(-1, 0);// face to the left 
             
                _movementDir.x -= 1f;
                

            }
            if (Input.GetKey(KeyCode.S))
            {
                
                _movementDir.y -= 1f;


            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.right = new Vector2(0, 0); // face to the right
            
                _movementDir.x += 1f;
            }
        }
    }
}
