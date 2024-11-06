// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages the ghost's behavior as it chases the player’s boat, with audio that intensifies as it gets closer
public class GhostChaser : MonoBehaviour
{
    public Transform playerBoat; // Reference to the player's boat
    public float speed = 0f; // speed of the ghost before the chase begins 
    public float catchUpSpeed = 2f; // Speed at which the ghost chases the boat once fuel is depleted
    private bool isCatchingUp = false; // Flag indicating if the chase has started
    private AudioSource ghostAudio; // Audio source for the ghost sound effect

    void Start()
    {
        // Get the AudioSource component attached to the ghost
        ghostAudio = GetComponent<AudioSource>();

        // Ensure sound does not play until the chase begins
        if (ghostAudio != null)
        {
            ghostAudio.loop = true; // Set audio to loop for continuous playback
            ghostAudio.volume = 0f; // Start with muted volume
        }
    }

    void Update()
    {
        // Check current fuel level of the player's boat
        float currentFuel = FindObjectOfType<FuelManager>().GetCurrentFuel();

        // If fuel is depleted and chase hasn't started, begin the chase
        if (currentFuel <= 0 && !isCatchingUp)
        {
            isCatchingUp = true; // Set the chase flag to true

            // Start playing the ghost sound when the chase begins
            if (ghostAudio != null)
            {
                ghostAudio.volume = 0.5f; // Set initial volume level for the chase
                ghostAudio.Play();
            }
        }

        // Set the speed based on whether the ghost is catching up
        float currentSpeed = isCatchingUp ? catchUpSpeed : speed;

        // Move the ghost towards the boat only when it's actively chasing
        if (isCatchingUp)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerBoat.position, currentSpeed * Time.deltaTime);

            // Adjust audio volume based on the ghost's proximity to the boat
            if (ghostAudio != null)
            {
                float distance = Vector2.Distance(transform.position, playerBoat.position);
                ghostAudio.volume = Mathf.Clamp01(1f - (distance / 10f)); // Volume increases as ghost gets closer
            }
        }

        // Check if the ghost has caught up with the boat
        if (Vector2.Distance(transform.position, playerBoat.position) < 0.1f)
        {
            // Trigger game over and load the end scene
            SceneManager.LoadScene("EndScene");
        }
    }
}
