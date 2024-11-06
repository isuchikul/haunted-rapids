// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the downward movement of obstacles at a specified speed
public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the obstacle moves downwards

    void Update()
    {
        // Move the obstacle downwards each frame
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
}
