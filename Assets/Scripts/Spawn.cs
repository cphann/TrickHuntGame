using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ghost;
    public GameObject kid;
    public int numberOfGhostsToSpawn;
    public int ghostCount = 0;
    public float spawnRangeX;
    public float spawnRangeY;
    public List<Sprite> ghostSprites;
    public List<Sprite> kidSprites;
    public int maxKidCount;
    public int kidCount;

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
        for (int i = ghostCount; i < numberOfGhostsToSpawn; i++)
        {
            Vector3 spawnPosition = new Vector2( Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
            if (kidCount < maxKidCount)
            {
                int spawnChoice = Random.Range(0, 1);
                if (spawnChoice == 0)
                {
                    GameObject newKid = Instantiate(kid, spawnPosition, Quaternion.identity);
                    SpriteRenderer ghostSr = newKid.GetComponent<SpriteRenderer>();
                    ghostSr.sprite = kidSprites[Random.Range(0, kidSprites.Count)];
                    kidCount++;
                }
                else if (spawnChoice == 1)
                {
                    GameObject newGhost = Instantiate(ghost, spawnPosition, Quaternion.identity);
                    SpriteRenderer ghostSr = newGhost.GetComponent<SpriteRenderer>();
                    ghostSr.sprite = ghostSprites[Random.Range(0, ghostSprites.Count)];
                    ghostCount++;
                }
            } else {
                GameObject newGhost = Instantiate(ghost, spawnPosition, Quaternion.identity);
                SpriteRenderer ghostSr = newGhost.GetComponent<SpriteRenderer>();
                ghostSr.sprite = ghostSprites[Random.Range(0, ghostSprites.Count)];
                ghostCount++;
            }
            
            
        }
    }

    void ReSpawn()
    {
        if (ghostCount < 10)
        {
            SpawnObjects();
        }

    }
}
