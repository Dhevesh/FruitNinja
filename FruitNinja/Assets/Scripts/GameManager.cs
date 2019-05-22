using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header ("Game")]
    public Text scoreText;
    public Text highScoreText;
    private int score;

    [Header("GameOverPanel")]
    public Text gameOverScoreText;
    public GameObject gameOverPanel;

    void Awake()
    {
        gameOverPanel.SetActive(false);
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = $"Current Score: {score.ToString()}";
    }

    public void OnBombHit()
    {

        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = $"Score: {score}";

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
        Time.timeScale = 1;
    }
}
