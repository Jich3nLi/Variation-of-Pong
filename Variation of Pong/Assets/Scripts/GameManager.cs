using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Reference to the ball in the scene
    public Ball ball;

    // UI heart images for Player 1
    public Image[] player1Hearts;

    // UI heart images for Player 2
    public Image[] player2Hearts;

    // References to both paddles
    public Paddle player1Paddle;
    public Paddle player2Paddle;

    // Current lives for each player
    private int _player1Lives = 3;
    private int _player2Lives = 3;

    // Singleton instance (only one GameManager exists)
    public static GameManager Instance;

    public AudioSource backgroundMusic;

    public AudioSource seSource;

    public AudioClip hitSound;

    public AudioClip paddleHit;

    public AudioClip scoreSound;

    // Stores which paddle last hit the ball
    private Paddle lastHitPaddle;

    // UI gameOver Panel
    public GameObject gameOverPanel;

    // gameOver Text
    public TMP_Text gameOverText;

    // Runs once when the object is created
    // Ensures only ONE GameManager exists (Singleton pattern)
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        CheckGameOver();
    }

    // Called when a paddle hits the ball
    // If the same paddle hits twice in a row, it gets penalized
    public void RegisterPaddleHit(Paddle paddle)
    {
        if (lastHitPaddle == paddle)
        {
            Penalize(paddle);
        }

        // Update last paddle that touched the ball
        lastHitPaddle = paddle;
    }

    // Determines which player should lose a life
    private void Penalize(Paddle paddle)
    {
        if (paddle is playerPaddle1)
        {
            P1LosesLives();
        }
        else if (paddle is playerPaddle2)
        {
            P2LosesLives();
        }
    }

    // Clears the last-hit paddle (useful when resetting a round)
    public void ResetLastHit()
    {
        lastHitPaddle = null;
    }

    // Player 1 loses one life
    // Disables one heart icon
    public void P1LosesLives()
    {
        if (_player1Lives > 0)
        {
            _player1Lives--;
            player1Hearts[_player1Lives].enabled = false;
            SEManager.Instance.PlayScoreSound();
        }
    }

    // Player 2 loses one life
    // Disables one heart icon
    public void P2LosesLives()
    {
        if (_player2Lives > 0)
        {
            _player2Lives--;
            player2Hearts[_player2Lives].enabled = false;
            SEManager.Instance.PlayScoreSound();
        }
    }

    // Resets both players' lives and re-enables all hearts
    public void ResetLives()
    {
        _player1Lives = 3;
        _player2Lives = 3;

        foreach (Image img in player1Hearts) img.enabled = true;
        foreach (Image img in player2Hearts) img.enabled = true;
    }

    // Resets paddles, ball, and lives for a new round
    public void ResetRound()
    {
        player1Paddle.ResetPositionPlayer1();
        player2Paddle.ResetPositionPlayer2();
        player1Paddle.SetNormal();
        player2Paddle.SetNormal();
        ball.ResetPosition();
        ball.AddStartingForce();
        lastHitPaddle = null;
    }

    void ShowGameOver(string winnerText)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = winnerText;
        Time.timeScale = 0f;
        backgroundMusic.Stop();
    }

    // Checks if any player has reached zero lives
    // If so, the game ends
    private void CheckGameOver()
    {
        if (_player1Lives <= 0)
        {
            ShowGameOver("Player 2 Wins!");
            StopBall();
        }
        else if (_player2Lives <= 0)
        {
            ShowGameOver("Player 1 Wins!");
            StopBall();    
        }
    }

    // Handles game-over behavior
    // Stops the ball and announces the winner
    private void StopBall()
    {
        ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }

    public void ResetGame()
    {
        player1Paddle.ResetPositionPlayer1();
        player2Paddle.ResetPositionPlayer2();
        player1Paddle.SetNormal();
        player2Paddle.SetNormal();
        ball.ResetPosition();
        ball.AddStartingForce();
        lastHitPaddle = null;
        ResetLives();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        backgroundMusic.Play();
    }

    public void EndGame()
    {
        Application.Quit();
    }
}

