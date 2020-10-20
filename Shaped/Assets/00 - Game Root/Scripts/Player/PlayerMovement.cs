using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static bool _facingRight;
    public static bool FacingRight { get { return _facingRight; } }
    float _moveSpeed = 9;
    Rigidbody _rb;
    PlayerAnimations _animator;

    Vector3 _movementDir;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<PlayerAnimations>();
    }

    private void FixedUpdate()
    {   
        if (_movementDir != Vector3.zero) // don't face one way as a standard
        {
            _animator.ActivateWalkingAnimation(true); //Activate the walking animation

        }else
        {
            _animator.ActivateWalkingAnimation(false); //end the walking animaation
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
                _movementDir.z += 1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(-1, 1, 1); // face to the left
                _facingRight = false;

                _movementDir.x -= 1f;
                

            }
            if (Input.GetKey(KeyCode.S))
            {             
                _movementDir.z -= 1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(1, 1, 1); // face to the right
                _facingRight = true;

                _movementDir.x += 1f;
            }
        }
    }
}
