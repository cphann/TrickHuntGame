using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject gameOverScreen;
    public GameObject youWinScreen;
    public Movement playerScript;

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void YouWin()
    {
        youWinScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Start()
    {
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (playerScript.heartCount != 1)
        {
            healthText.text = playerScript.heartCount.ToString() + " hearts";
        }
        else
        {
            healthText.text = playerScript.heartCount.ToString() + " heart";
        }
        
        if (playerScore == 20)
        {
            YouWin();
        }
    }
}
