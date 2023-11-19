using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public float initialSpawnRate = 1.0f;
    public float timeBetweenWaves = 3.0f;
    public int initialEnemyCount;
    public GameObject enemyPrefab;

    // Reference to the spawn point
    public Transform spawnPoint;

    private bool waveIsDone = true;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)  // Infinite loop for continuous spawning
        {
            if (waveIsDone)
            {
                waveIsDone = false;

                for (int i = 0; i < initialEnemyCount; i++)
                {
                    // Instantiate enemies at the specified spawn point
                    GameObject enemyClone = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                    yield return new WaitForSeconds(initialSpawnRate);
                }

                initialSpawnRate -= 0.1f;
                initialEnemyCount += 3;

                yield return new WaitForSeconds(timeBetweenWaves);
                waveIsDone = true;
            }
            yield return null;
        }
    }
}

