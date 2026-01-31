using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200.0f;
    private Rigidbody2D _rigidbody;

    private Paddle lastHitPaddle; // Stores the last paddle that hit the ball

    // Called once when the object is created; gets the Rigidbody2D reference
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Called at the start of the game; centers the ball and launches it
    private void Start()
    {
        ResetPosition(); 
        AddStartingForce();
    }

    // Applies a random initial force to start the ball moving
    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.speed);
    }

    // Adds a force to the ball (used for bouncing)
    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

    // Records which paddle last hit the ball
    public void RegisterHit(Paddle paddle)
    {
        lastHitPaddle = paddle;
    }

    // Returns the paddle that last hit the ball
    public Paddle GetLastHitPaddle()
    {
        return lastHitPaddle;
    }

    // Clears the record of the last paddle hit
    public void ResetLastHit()
    {
        lastHitPaddle = null;
    }

    // Resets the ball to the center and stops its movement
    public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.linearVelocity = Vector3.zero;
    }
}
