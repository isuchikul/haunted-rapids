// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Manages the End Screen display of final and high scores, with functionality to restart the game
public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI FinalScoreText; // UI element to display the final time elapsed
    public TextMeshProUGUI HighScoreTextDisplay; // UI element to display the high score
    private float highScore; // High score value loaded from PlayerPrefs
    private float timeElapsed; // Final time elapsed, loaded from PlayerPrefs

    void Start()
    {
        // Load the saved high score and time elapsed values from PlayerPrefs
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        timeElapsed = PlayerPrefs.GetFloat("TimeElapsed", 0f);

        // Update UI elements with the loaded high score and final time elapsed
        FinalScoreText.text = $"Time Elapsed: {timeElapsed:F2}s"; 
        HighScoreTextDisplay.text = $"High Score: {highScore:F2}s";
    }

    // Restart the game by loading the main gameplay scene
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
