// Ella Suchikul
// RedID: 826715936

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns obstacles at specified intervals with random horizontal positions, ensuring enough space for the player to navigate
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array of obstacle prefabs for random selection
    public float initialSpawnRate = 2.5f; // Initial time between obstacle spawns
    public float minimumSpawnRate = 0.8f; // Minimum time between spawns at maximum difficulty
    public float spawnRateDecrease = 0.05f; // Amount to decrease spawn rate over time
    public float spawnRangeX = 2.5f; // Horizontal range within which obstacles can spawn
    public float minObstacleDistance = 1.5f; // Minimum horizontal distance between consecutive obstacles
    public float boatWidth = 1.0f; // Width of the boat to ensure safe gaps
    private float currentSpawnRate; // Current spawn rate, gradually decreased to increase difficulty
    private float lastSpawnX = float.MinValue; // Stores the x-position of the last spawned obstacle

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
        StartCoroutine(SpawnObstaclesRepeatedly());
    }

    // Repeatedly spawns obstacles at intervals based on the current spawn rate
    IEnumerator SpawnObstaclesRepeatedly()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(currentSpawnRate);
        }
    }

    // Spawns an obstacle at a random x-position within range, ensuring spacing from the last obstacle
    void SpawnObstacle()
    {
        float randomX;
        int maxAttempts = 10; // Limit attempts to find a valid position to avoid crashing
        int attempts = 0;

        // Ensure sufficient space between consecutive obstacles
        do
        {
            randomX = Random.Range(-spawnRangeX, spawnRangeX);
            attempts++;
        } while (Mathf.Abs(randomX - lastSpawnX) < minObstacleDistance + boatWidth && attempts < maxAttempts);

        // If no valid position is found within max attempts, skip spawning
        if (attempts >= maxAttempts)
        {
            return;
        }

        // Spawn obstacle at calculated position
        Vector2 spawnPosition = new Vector2(randomX, Camera.main.orthographicSize + 1f);
        GameObject newObstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPosition, Quaternion.identity);
        
        lastSpawnX = randomX; // Update last spawn position
    }
}
