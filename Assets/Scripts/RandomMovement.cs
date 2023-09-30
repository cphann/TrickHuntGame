using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMovement : MonoBehaviour
{
    public float speed = 4.0f;
    public float range;
    public float max_x;
    public float max_y;
    public Spawn spawnScript;
    public Movement playerScript;
    public LogicScript logicScript;
    Vector2 newPos;

    private void Start()
    {
        SetNewPos();
        spawnScript = FindObjectOfType<Spawn>();
        playerScript = FindObjectOfType<Movement>();
        logicScript = FindObjectOfType<LogicScript>();
    }

    private void Update()
    {
        // Move the object forward
        transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, newPos) < range)
        {
            SetNewPos();
        }
    }

    void SetNewPos()
    {
        newPos = new Vector2(Random.Range(-max_x, max_x), Random.Range(-max_y, max_y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ghost") || collision.gameObject.CompareTag("kid") ||
            collision.gameObject.CompareTag("border"))
        {
            // Collision with an obstacle detected, set a new position
            SetNewPos();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
                // Collision with player detected, de-spawn
                if (gameObject.CompareTag("ghost"))
                {
                    Destroy(gameObject);
                    spawnScript.ghostCount--;
                    logicScript.AddScore(1);
                }
                else if (gameObject.CompareTag("kid"))
                {
                    playerScript.heartCount--;
                }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ghost") || collision.gameObject.CompareTag("kid") ||
            collision.gameObject.CompareTag("border"))
        {
            // Collision with an obstacle detected, set a new position
            SetNewPos();
        }
    }
}
