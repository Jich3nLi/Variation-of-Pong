using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance;
    public AudioSource seSource;
    public AudioClip hitSound;

    public AudioClip scoreSound;

    public AudioClip paddleHit;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayHitSound()
    {
        if (seSource != null && hitSound != null)
        {
            seSource.PlayOneShot(hitSound);
        }
    }

    public void PlayScoreSound()
    {
        if (seSource != null && scoreSound != null)
        {
            seSource.PlayOneShot(scoreSound);
        }
    }

    public void PlayPaddleHit()
    {
        if (seSource != null && paddleHit != null)
        {
            seSource.PlayOneShot(paddleHit);
        }
    }
}