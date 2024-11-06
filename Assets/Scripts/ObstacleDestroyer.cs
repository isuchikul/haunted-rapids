// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatically destroys obstacles that fall below a specified threshold
public class ObstacleDestroyer : MonoBehaviour
{
    public float destroyThreshold = -6f; // Y-position threshold for destroying obstacles

    void Update()
    {
        // Find all obstacles in the scene with the "Obstacle" tag
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        // Loop through each obstacle and check if it has fallen below the destroy threshold
        foreach (GameObject obstacle in obstacles)
        {
            // Destroy the obstacle if its position is below the threshold
            if (obstacle.transform.position.y < destroyThreshold)
            {
                Destroy(obstacle);
            }
        }
    }
}
