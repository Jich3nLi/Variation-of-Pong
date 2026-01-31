using UnityEngine;

public class scoringZone : MonoBehaviour
{
    // Called when an object enters this scoring zone
    // If the ball enters, penalizes the paddle that last hit the ball
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Scoring zone triggered by: " + collision.gameObject.name);

        Ball ball = collision.GetComponent<Ball>();
        if (ball == null) return;

        Paddle lastPaddle = ball.GetLastHitPaddle();
        if (lastPaddle != null)
        {
            GameManager.Instance.RegisterPaddleHit(lastPaddle);
            ball.ResetLastHit();
        }

        GameManager.Instance.ResetRound();
    }
}
