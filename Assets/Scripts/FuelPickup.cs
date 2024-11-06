// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the functionality of the fuel pickup, including refueling the player and playing a sound effect
public class FuelPickup : MonoBehaviour
{
    public float fuelAmount = 20f; // Amount of fuel restored upon pickup
    public AudioClip fuelSound; // Sound effect played upon collection

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player (tagged "Player") collides with the fuel pickup
        if (other.CompareTag("Player"))
        {
            FuelManager fuelManager = other.GetComponent<FuelManager>();
            if (fuelManager != null)
            {
                // Add fuel to the player's fuel manager
                fuelManager.Refuel(fuelAmount);

                // Play the fuel pickup sound
                PlaySound();

                // Destroy the fuel pickup after collection
                Destroy(gameObject);
            }
        }
    }

    // Plays the fuel pickup sound effect
    private void PlaySound()
    {
        // Get the AudioSource component from the fuel prefab
        AudioSource audioSource = GetComponent<AudioSource>();

        // If there's an AudioSource and it has an assigned clip
        if (audioSource != null && audioSource.clip != null)
        {
            // Create a temporary GameObject to play the sound independently
            GameObject tempAudio = new GameObject("TempFuelAudio");
            AudioSource tempAudioSource = tempAudio.AddComponent<AudioSource>();
            tempAudioSource.clip = audioSource.clip;
            tempAudioSource.volume = audioSource.volume; 
            tempAudioSource.Play();

            // Destroy the temporary GameObject after the sound finishes
            Destroy(tempAudio, audioSource.clip.length);
        }
    }
}
