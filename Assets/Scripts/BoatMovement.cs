// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the boat's movement and keeps it within river boundaries
public class BoatMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the boat
    public Transform riverBackground; // Reference to the river background for boundary calculations
    private Rigidbody2D rb; // Rigidbody component for controlling physics-based movement

    private float leftBoundary; // Left boundary limit for the boat
    private float rightBoundary; // Right boundary limit for the boat
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Calculate boundaries based on the river background’s width
        float riverHalfWidth = riverBackground.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        
        // Set boundaries so the boat stays within the river
        leftBoundary = riverBackground.position.x - riverHalfWidth + 1.5f;  // Buffer to avoid boat going above shore
        rightBoundary = riverBackground.position.x + riverHalfWidth - 1.5f; // Buffer to avoid boat going above shore
    }

    void Update()
    {
        // Get horizontal input from player (A/D keys or arrow keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        // Apply horizontal movement to the boat
        Vector2 movement = new Vector2(moveHorizontal * moveSpeed, 0);
        rb.velocity = movement;

        // Clamp the boat's position within the calculated river boundaries
        float clampedX = Mathf.Clamp(rb.position.x, leftBoundary, rightBoundary);
        rb.position = new Vector2(clampedX, rb.position.y);
    }
}
