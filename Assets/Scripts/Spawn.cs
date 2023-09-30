using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ghost;
    public int numberOfGhostsToSpawn;
    public int numberOfGhosts = 0;
    public float spawnRangeX = 11.0f;
    public float spawnRangeY = 5.0f;

    void Start()
    {
        SpawnObjects();
    }

    void Update()
    {
        ReSpawn();
    }

    void SpawnObjects()
    {
        for (int i = numberOfGhosts; i < numberOfGhostsToSpawn; i++)
        {
            Vector3 spawnPosition = new Vector2( Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
            Instantiate(ghost, spawnPosition, Quaternion.identity);
            numberOfGhosts++;
        }
    }

    void ReSpawn()
    {
        if (numberOfGhosts < 10)
        {
            SpawnObjects();
        }

    }
}
