using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float baseSpeed = 30.0f;          // Normal movement speed
    public float penalizedSpeed = 10.0f;      // Speed when penalized

    protected float currentSpeed;            // Current movement speed
    protected Rigidbody2D _rigidbody;        // Physics component

    // Called once when the paddle is created
    // Initializes Rigidbody and starting speed
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        currentSpeed = baseSpeed;
    }

    // Called when this paddle collides with another object
    // Detects ball hits and registers the hit with the GameManager
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        Paddle otherPaddle = collision.gameObject.GetComponent<Paddle>();
        if (ball != null)
        {
            // Let the ball know it was hit
            ball.RegisterHit(this);

            HandleBallHit();

            GameManager.Instance.RegisterPaddleHit(this);
        }

        if (otherPaddle != null)
        {
            SEManager.Instance.PlayPaddleHit();
        }
    }

    // Allows child paddle classes to define custom hit behavior
    protected virtual void HandleBallHit()
    {
        // Overridden in subclasses
    }

    // Restores paddle speed to normal
    public void SetNormal()
    {
        currentSpeed = baseSpeed;
    }

    // Applies the penalized speed
    public void SetPenalized()
    {
        currentSpeed = penalizedSpeed;
    }

    // Resets paddle position and stops movement
    public void ResetPositionPlayer1()
    {
        _rigidbody.position = new Vector2(-5.0f, -2.0f);
        _rigidbody.linearVelocity = Vector2.zero;
    }

    public void ResetPositionPlayer2()
    {
        _rigidbody.position = new Vector2(5.0f, -2.0f);
        _rigidbody.linearVelocity = Vector2.zero;
    }
}

