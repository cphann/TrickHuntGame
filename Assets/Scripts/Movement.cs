using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveLeftRight(false);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeftRight(true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveUpDown(false);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUpDown(true);
        }
    }

    void MoveLeftRight(bool left)
    {
        if (left)
        {
            Vector3 pos = transform.position;
            pos = new(pos.x - speed * Time.deltaTime, pos.y, pos.z);
            transform.position = pos;
        }

        else
        {
            Vector3 pos = transform.position;
            pos = new(pos.x + speed * Time.deltaTime, pos.y, pos.z);
            transform.position = pos;
        }
    }

    void MoveUpDown (bool up) 
    {
        if (up)
        {
            Vector3 pos = transform.position;
            pos = new(pos.x, pos.y + speed * Time.deltaTime, pos.z);
            transform.position = pos;
        }

        else
        {
            Vector3 pos = transform.position;
            pos = new(pos.x, pos.y - speed * Time.deltaTime, pos.z);
            transform.position = pos;
        }
    }
}
