using UnityEngine;
using UnityEngine.InputSystem;

public class playerPaddle2 : Paddle 
{
    private Vector2 _direction;

    // Reads keyboard input each frame and sets movement direction
    private void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            _direction = Vector2.up;
        } 
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            _direction = Vector2.down;
        } 
        else if (Keyboard.current.leftArrowKey.isPressed)
        {
            _direction = Vector2.left;
        } 
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            _direction = Vector2.right;
        } 
        else
        {
            _direction = Vector2.zero;
        }
    }

    // Applies movement force in FixedUpdate for stable physics behavior
    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0) 
        {
            _rigidbody.AddForce(_direction * this.currentSpeed);
        }
    }

    // Called when this paddle hits the ball
    // Penalizes this paddle and restores the other paddle's speed
    protected override void HandleBallHit()
    {
        SetPenalized();

        playerPaddle1 paddle1 = FindObjectOfType<playerPaddle1>();
        paddle1.SetNormal();
    }
}
