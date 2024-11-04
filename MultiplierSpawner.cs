
using System.Collections;
using UnityEngine;

public class MultiplierSpawner : MonoBehaviour
{
    public GameObject multiplierPrefab; // Reference to the multiplier prefab
    public Transform player; // Reference to the player's transform
    public Transform ground; // Reference to the ground object

    private void Start()
    {
        // Find the player GameObject in the scene
        player = GameObject.FindWithTag("Player").transform; // Ensure your player GameObject is tagged "Player"

        // Start spawning multipliers
        InvokeRepeating("SpawnMultiplier", 2f, 5f); // Adjust the timing as needed
    }

    private void SpawnMultiplier()
{
    Vector3 spawnPosition;

    float yOffset = 0.5f; // Slight offset above ground or player height
    float zOffset = 5f;   // Position of z in front of player
    int attempts = 0;

    do
    {
        // Use the player's Y position as a base, add a small offset
        float randomY = player.position.y + yOffset; // Position just above player

        // Position aligned horizontally with the player or centered
        float xPosition = player.position.x;
        float zPosition = player.position.z + zOffset;

        spawnPosition = new Vector3(xPosition, randomY, zPosition);
        attempts++;

        if (attempts > 10)
        {
            Debug.LogWarning("Could not find a safe spawn position for multiplier.");
            return;
        }
    }
    while (IsNearObstacle(spawnPosition));

    GameObject multiplier = Instantiate(multiplierPrefab, spawnPosition, Quaternion.identity);
    multiplier.transform.SetParent(ground); // Attach multiplier to ground
}


    private bool IsNearObstacle(Vector3 position)
    {
        // Implement your logic to check if the position is near an obstacle
        // Return true if near an obstacle, otherwise false
        return false; // Placeholder
    }
}
