// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Manages game timer, high score tracking, and updates related UI elements
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TimerText; // UI element to display the elapsed time
    public TextMeshProUGUI HighScoreText; // UI element to display the high score

    private float currentTime = 0f; // Tracks the current game time
    private float highScore = 0f; // Stores the high score

    void Start()
    {
        // Load the high score from PlayerPrefs if it exists
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        UpdateHighScoreText();
    }

    void Update()
    {
        // Increment the timer based on elapsed time
        currentTime += Time.deltaTime;
        UpdateTimerText();

        // Check if the current time surpasses the high score
        if (currentTime > highScore)
        {
            highScore = currentTime;
            PlayerPrefs.SetFloat("HighScore", highScore); // Save the new high score to PlayerPrefs
            UpdateHighScoreText();
        }
    }

    // Updates the timer UI to display the elapsed game time
    void UpdateTimerText()
    {
        TimerText.text = $"Time Elapsed: {currentTime:F2}s";
    }

    // Updates the high score UI to display the current high score
    void UpdateHighScoreText()
    {
        HighScoreText.text = $"High Score: {highScore:F2}s";
    }

    // Public getter to retrieve the current time (used by other scripts)
    public float GetCurrentTime()
    {
        return currentTime;
    }

    // Public getter to retrieve the high score (used by other scripts)
    public float GetHighScore()
    {
        return highScore;
    }
}
