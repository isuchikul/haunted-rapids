// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the continuous vertical scrolling of the background to simulate movement
public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 2f; // Speed at which the background scrolls

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    private float spriteHeight; // Height of the background sprite

    void Start()
    {
        // Cache the SpriteRenderer component attached to the background
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if the SpriteRenderer component is found
        if (spriteRenderer == null)
        {
            return;
        }

        // Calculate the height of the sprite to use for position reset
        spriteHeight = spriteRenderer.bounds.size.y;
    }

    void Update()
    {
        // Move the background downward to create a scrolling effect
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        // Check if the background has moved completely off the screen
        if (transform.position.y <= -spriteHeight)
        {
            // Reset the position to create a seamless loop
            transform.position = new Vector3(transform.position.x, spriteHeight, transform.position.z);
        }
    }
}



