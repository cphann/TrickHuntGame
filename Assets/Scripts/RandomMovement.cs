using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 4.0f;
    public float range;
    public float max_x;

    public float max_y;
    Vector2 newPos;

    private void Start()
    {
        SetNewPos();
    }
    private void Update()
    {
        // Move the object forward
        transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, newPos) < range)
        {
            SetNewPos();
        }
    }
    void SetNewPos ()
    {
        newPos = new Vector2(Random.Range(-max_x, max_x), Random.Range(-max_y, max_y));
    }
}
