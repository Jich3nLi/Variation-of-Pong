using UnityEngine;

public class bouncySurface : MonoBehaviour
{
    public float bounceStrength;

    // Called when this object collides with another 2D object
    // Applies a bounce force to the ball if the ball hits this surface
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceStrength);
            SEManager.Instance.PlayHitSound();
        }
    }
}
