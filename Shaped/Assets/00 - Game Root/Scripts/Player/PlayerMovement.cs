using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float MOVE_SPEED = 12;
    static bool _moving;
        public static bool Moving { get { return _moving; } }
    static bool _facingLeft;
    public static bool FacingLeft { get { return _facingLeft; } }
    
    Rigidbody _rb;
    CharacterAnimator _animator;

    Vector3 _movementDir;
   

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<CharacterAnimator>();
    }

    private void FixedUpdate()
    {
        if (_movementDir != Vector3.zero) // don't face one way as a standard
            _moving = true;
        else
            _moving = false;

        _rb.velocity = _movementDir.normalized * MOVE_SPEED; // move in the direction the player wants at a set speed
    }

    void Update()
    {
        _movementDir = Vector2.zero; //zero out so that if player isnt pushing a button the stop.

        if (GameManager.CanMove) // while nobody is speaking 
        {
            if (Input.GetKey(KeyCode.W))
            {
                _movementDir.z += 1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(1, 1, 1); // face to the left
                _facingLeft = true;

                _movementDir.x -= 1f;
                

            }
            if (Input.GetKey(KeyCode.S))
            {             
                _movementDir.z -= 1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(-1, 1, 1); // face to the right
                _facingLeft = false;

                _movementDir.x += 1f;
            }
        }
    }

    public void ChangeFaceingDirection(bool facingLeft)
    {
        _facingLeft = facingLeft;
    }
}
