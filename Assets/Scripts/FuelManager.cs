// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// Manages the boat's fuel level, depletion over time, refueling, and triggers game over when fuel is depleted
public class FuelManager : MonoBehaviour
{
    public Slider FuelSlider; // UI element representing fuel level
    public TextMeshProUGUI FuelText; // UI element to display fuel percentage
    public float maxFuel = 100f; // Maximum amount of fuel
    public float fuelConsumptionRate = 2f; // Rate at which fuel depletes per second
    private float currentFuel; // Current fuel level

    void Start()
    {
        // Initialize fuel to maximum and update UI elements
        currentFuel = maxFuel;
        FuelSlider.maxValue = maxFuel;
        FuelSlider.value = currentFuel;
        UpdateFuelText();
    }

    void Update()
    {
        // Decrease fuel over time and update UI elements
        currentFuel -= fuelConsumptionRate * Time.deltaTime;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel); // Ensure fuel doesn't drop below 0
        FuelSlider.value = currentFuel;
        UpdateFuelText();

        // Trigger game over if fuel runs out
        if (currentFuel <= 0)
        {
            // Access GameManager to get time elapsed and high score
            float timeElapsed = FindObjectOfType<GameManager>().GetCurrentTime();
            float highScore = FindObjectOfType<GameManager>().GetHighScore();

            // Save time elapsed and high score for the end screen display
            PlayerPrefs.SetFloat("TimeElapsed", timeElapsed);
            PlayerPrefs.SetFloat("HighScore", highScore);

            // Load the end screen scene
            //SceneManager.LoadScene("EndScene");
            // Commented out because now when skeleton attacks (only when fuel is out), it generates end screen. 
        }
    }

    // Refuels the boat by a specified amount and updates UI
    public void Refuel(float amount)
    {
        currentFuel = Mathf.Min(currentFuel + amount, maxFuel); // Refuel without exceeding max fuel
        FuelSlider.value = currentFuel;
        UpdateFuelText();
    }

    // Updates the fuel text to display the current fuel percentage
    void UpdateFuelText()
    {
        float fuelPercent = (currentFuel / maxFuel) * 100;
        FuelText.text = $"Fuel: {fuelPercent:F1}%";
    }

    // Returns the current fuel level, useful for other scripts that need to access this value
    public float GetCurrentFuel()
    {
        return currentFuel;
    }
}
