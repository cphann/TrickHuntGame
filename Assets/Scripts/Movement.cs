using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    public int speed;
    private SpriteRenderer _spriteRenderer;
    private bool _isMovingLeft = false;
    public int heartCount;
    public LogicScript logicScript;
    public TextMeshProUGUI healthText;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        logicScript = FindObjectOfType<LogicScript>();
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

        FlipPlayerSprite();

        if (heartCount != 1)
        {
            healthText.text = heartCount.ToString() + " hearts";
        }
        else
        {
            healthText.text = heartCount.ToString() + " heart";
        }
        
        if (heartCount == 0)
        {
            logicScript.GameOver();
        }
    }

    void MoveLeftRight(bool left)
    {
        if (left)
        {
            Vector3 pos = transform.position;
            pos = new(pos.x - speed * Time.deltaTime, pos.y, pos.z);
            transform.position = pos;
            _isMovingLeft = true;
        }

        else
        {
            Vector3 pos = transform.position;
            pos = new(pos.x + speed * Time.deltaTime, pos.y, pos.z);
            transform.position = pos;
            _isMovingLeft = false;
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

    private void FlipPlayerSprite()
    {
        _spriteRenderer.flipX = _isMovingLeft;
    }
    
}
