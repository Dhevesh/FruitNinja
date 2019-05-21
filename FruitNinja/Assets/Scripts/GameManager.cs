using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    private int score;

    public void IncreaseScore()
    {
        score++;
        scoreText.text = $"Current Score: {score.ToString()}";
    }
}
