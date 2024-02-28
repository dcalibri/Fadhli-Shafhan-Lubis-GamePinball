using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Variable to store the current score
    public float score;

    // Variable to store the highest score
    public float highestScore;

    // Variable to control whether to save the highest score during gameplay
    public bool saveInGame = true;

    void Start()
    {
        // Load the highest score from player preferences
        LoadHighestScore();

        // Reset score to 0 at the start of the game
        ResetScore();
    }

    // Method to add score based on the provided value
    public void AddScore(float addition)
    {
        score += addition;
        
        if (score > highestScore)
        {
            highestScore = score;
        }
            
        highestScore = score;
        // Check if the current score is higher than the highest score
        if (saveInGame)
        {
            // Update the highest score
            

            // Save the new highest score
            SaveHighestScore();
        }
    }

    // Method to reset the score to 0
    public void ResetScore()
    {
        score = 0;
    }

    // Method to save the highest score to player preferences
    private void SaveHighestScore()
    {
        PlayerPrefs.SetFloat("HighestScore", highestScore);
        PlayerPrefs.Save();
    }

    // Method to load the highest score from player preferences
    private void LoadHighestScore()
    {
        highestScore = PlayerPrefs.GetFloat("HighestScore", 0f);
    }

    // Method to be called to save the score (for debugging purposes)
    public void SaveScore()
    {
        Debug.Log("Score Saved: " + score);
    }
}
