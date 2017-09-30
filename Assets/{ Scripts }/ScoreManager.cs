using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private Text scoreText;
    private Text livesText;
    private Text gameOverText;
    private int scoreCount;
    private SessionManager session;

    private void Start()
    {
        session = GetComponent<SessionManager>();
    }

    public void InitializeScore()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        livesText = GameObject.FindGameObjectWithTag("LivesText").GetComponent<Text>();
        gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
        gameOverText.text = "";
        scoreCount = 0;
        ScoreUpdate();
    }

    public void ScoreAdd(int value)
    {
        scoreCount += value;
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
        scoreText.text = "Score: " + scoreCount.ToString();
    }

    private void ScoreReset()
    {
        scoreCount = 0;
        ScoreUpdate();
    }

    public void UpdateHighScore()
    {
        if(scoreCount > session.highScore)
        {
            session.highScore = scoreCount;
        }
    }

    public void LivesUpdate(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    public void GameOverMessage()
    {
        gameOverText.text = "GAME OVER";
    }
}