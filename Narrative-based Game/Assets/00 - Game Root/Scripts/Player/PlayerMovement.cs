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
        if (_movementDir != Vector2.zero)
        {
            transform.right = _movementDir.normalized;
        }
        
        _rb.velocity = _movementDir.normalized * _moveSpeed;
    }
    void Update()
    {
        _movementDir = Vector2.zero;
        
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
