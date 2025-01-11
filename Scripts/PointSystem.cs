using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class PointSystem : MonoBehaviour
{
    public TMP_Text scoreText; 
    public GameObject gameOverPanel; 
    private int score = 0; 
    public TMP_Text finalScoreText;
    public CameraFollow cameraFollow; 
    private int speedIncreaseThreshold = 20; 
    private float speedMultiplier = 1.1f; 
    private float reducedMultiplier = 1.05f; 

    

    void Start()
    {
        UpdateScoreUI(); // Initialize the score display
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Hide Game Over panel initially
        }
    }

    // Method to add points
    public void AddPoints(int amount)
    {
        score += amount;
        UpdateScoreUI();

        // Increase Camera movement speed
        if (score % speedIncreaseThreshold == 0)
        {
            if (score <= 40)
            {
                cameraFollow.IncreaseSpeed(speedMultiplier);
            }
            else
            {
                cameraFollow.IncreaseSpeed(reducedMultiplier);
            }
        }
    }

    // Method to trigger Game Over
    public void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            if (finalScoreText != null)
            {
                finalScoreText.text = "Final Score: " + score; 
            }
        }
        Time.timeScale = 0; 
    }

    // Method to reset points
    public void ResetPoints()
    {
        score = 0;
        //Debug.Log("Score reset to 0.");
        UpdateScoreUI();
    }

    // Updates the UI text
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "" + score;
        }
        else
        {
            //Debug.LogWarning("Score Text is not assigned in the inspector.");
        }
    }

    // Expose the score for other scripts
    public int GetScore()
    {
        return score;
    }

    // Method to restart the game
    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
