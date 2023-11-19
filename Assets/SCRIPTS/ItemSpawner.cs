using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;  // Reference to the item prefab to be spawned
    public Transform spawnPoint;   // Reference to the spawn point

    public float spawnInterval = 5f;  // Time interval between spawns

    void Start()
    {
        // Start spawning items repeatedly
        InvokeRepeating("SpawnItem", 0f, spawnInterval);
    }

    void SpawnItem()
    {
        // Instantiate the item at the spawn point
        GameObject itemInstance = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);

        // You can customize the spawned item's behavior or appearance here if needed

        // Destroy the item after a certain time (e.g., 10 seconds)
        Destroy(itemInstance, 10f);
    }
}
