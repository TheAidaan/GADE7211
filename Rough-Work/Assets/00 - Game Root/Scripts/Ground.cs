using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    bool _moveL, _moveR;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 _movement = Vector2.zero;

        if (_moveR)
        {
            _movement = (Vector2.left * -2);
            _moveR = false;
        }

        if (_moveL)
        {
            _movement = (Vector2.left * 2);
            _moveL = false;
        }

        _rb.velocity = _movement;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
            _moveR = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _moveL = true;
        }
    }
}
