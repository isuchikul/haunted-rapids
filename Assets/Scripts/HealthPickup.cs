// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the functionality of the health pickup, including healing the player and playing a sound effect
public class HealthPickup : MonoBehaviour
{
    public int healAmount = 20; // Amount of health restored upon pickup
    public AudioClip healthSound; // Sound effect played upon collection

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player (tagged "Player") collides with the health pickup
        if (other.CompareTag("Player"))
        {
            HealthManager healthManager = other.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                // Add health to the player's health manager
                healthManager.Heal(healAmount);

                // Play the health pickup sound
                PlaySound();

                // Destroy the health pickup after collection
                Destroy(gameObject);
            }
        }
    }

    // Plays the health pickup sound effect
    void PlaySound()
    {
        // Create a temporary GameObject to play the sound independently
        GameObject tempAudio = new GameObject("TempAudio");
        AudioSource audioSource = tempAudio.AddComponent<AudioSource>();
        audioSource.clip = healthSound;
        audioSource.playOnAwake = false;

        // Play the sound and destroy the temporary GameObject after the sound finishes
        audioSource.Play();
        Destroy(tempAudio, healthSound.length);
    }
}
