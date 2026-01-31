using UnityEngine;
using UnityEngine.InputSystem;

public class playerPaddle1 : Paddle 
{
    private Vector2 _direction;

    private void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            _direction = Vector2.up;
        } else if (Keyboard.current.sKey.isPressed)
        {
            _direction = Vector2.down;
        } else if (Keyboard.current.aKey.isPressed)
        {
            _direction = Vector2.left;
        } else if (Keyboard.current.dKey.isPressed)
        {
            _direction = Vector2.right;
        } else
        {
            _direction = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0) 
        {
            _rigidbody.AddForce(_direction * this.currentSpeed);
        }
    }

    protected override void HandleBallHit()
    {
        SetPenalized();

        playerPaddle2 paddle2 = FindObjectOfType<playerPaddle2>();
        paddle2.SetNormal();
    }
}
