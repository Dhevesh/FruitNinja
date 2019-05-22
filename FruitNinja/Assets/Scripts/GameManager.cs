using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header ("Game")]
    public Text scoreText;
    public Text highScoreText;
    public Text timeText;
    public int score;
    public int highScore;
    public float time = 3000f;

    [Header("GameOverPanel")]
    public GameObject gameOverPanel;
    public Text gameOverScoreText;
    public Text gameOverHighScoreText;
    

    void Update()
    {
        if (Time.timeScale != 0)
        {
            time--;
            if (time == 0)
            {
                OnBombHit();
                time = 3000f;
            }
            timeText.text = $"Time Remaining: {Mathf.RoundToInt((time / 100)).ToString()}s";
        }
        
    }
    void Awake()
    {
        gameOverPanel.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = $"Best: {highScore}";
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = $"Current Score: {score.ToString()}";
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = $"Best: {score.ToString()}";
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = $"Score: {score}";
        gameOverHighScoreText.text = $"Best: {PlayerPrefs.GetInt("HighScore").ToString()}";
    }

    public void OnRestartClick()
    {
        gameOverScoreText.text = "Score: 0";
        score = 0;
        scoreText.text = "Current Score: 0";
        gameOverPanel.SetActive(false);
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(go);
        }
        time = 3000f;
        Time.timeScale = 1;

    }
}
