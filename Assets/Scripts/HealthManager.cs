// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement;

// Manages the player's health, handles collisions with obstacles, and triggers game over when health is depleted
public class HealthManager : MonoBehaviour
{
    public Slider HealthSlider; // UI slider to display health level
    public TextMeshProUGUI HealthText; // UI text to display health percentage

    public int maxHealth = 100; // Maximum health value
    public int damagePerCollision = 10; // Damage taken per obstacle collision
    private int currentHealth; // Tracks the current health level

    void Start()
    {
        // Initialize health and update UI
        currentHealth = maxHealth;
        HealthSlider.maxValue = maxHealth;
        HealthSlider.value = currentHealth;
        UpdateHealthText();
    }

    // Updates the health percentage text
    void UpdateHealthText()
    {
        float healthPercent = ((float)currentHealth / maxHealth) * 100;
        HealthText.text = $"Health: {healthPercent:F1}%";
    }

    // Handles collision with obstacles, deducts health, and plays sound effect
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Play collision sound and apply damage
            PlayObstacleSound(collision.gameObject);
            TakeDamage(damagePerCollision);
            Destroy(collision.gameObject);  //Remove the obstacle after collision
        }
    }

    // Reduces health by a specified damage amount and updates UI
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamp health within 0 and maxHealth
        HealthSlider.value = currentHealth;
        UpdateHealthText();

        // If health reaches zero, save score data and trigger game over
        if (currentHealth <= 0)
        {
            // Save time elapsed and high score in PlayerPrefs
            float timeElapsed = FindObjectOfType<GameManager>().GetCurrentTime();
            float highScore = FindObjectOfType<GameManager>().GetHighScore();

            PlayerPrefs.SetFloat("TimeElapsed", timeElapsed);
            PlayerPrefs.SetFloat("HighScore", highScore);

            // Load the end screen
            SceneManager.LoadScene("EndScene");
        }
    }

    // Increases health by a specified amount (used for healing pickups) and updates UI
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // Heal without exceeding max health
        HealthSlider.value = currentHealth;
        UpdateHealthText();
    }

    // Plays a sound effect from an obstacle upon collision
    private void PlayObstacleSound(GameObject obstacle)
    {
        AudioSource audioSource = obstacle.GetComponent<AudioSource>();

        // If the obstacle has an AudioSource with a clip, play the sound
        if (audioSource != null && audioSource.clip != null)
        {
            GameObject tempAudio = new GameObject("TempAudio");
            AudioSource tempAudioSource = tempAudio.AddComponent<AudioSource>();
            tempAudioSource.clip = audioSource.clip;
            tempAudioSource.volume = audioSource.volume;
            tempAudioSource.Play();

            // Destroy the temporary GameObject after the sound finishes
            Destroy(tempAudio, audioSource.clip.length);
        }
    }
}
