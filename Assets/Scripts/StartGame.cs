// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages the Start Screen's play button to load the main game scene
public class StartGame : MonoBehaviour
{
    // Loads the main game scene when called (triggered by play button)
    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");  // Load the main game scene
    }
}

