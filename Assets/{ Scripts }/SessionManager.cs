using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public Transform player;
    public bool sessionRunning;
    public int playerLives;
    public int highScore;
    private int playerLivesAtStart;
    private LevelManager lm;
    private ScoreManager sm;

    private void Start()
    {
        lm = GetComponent<LevelManager>();
        sm = GetComponent<ScoreManager>();
        playerLivesAtStart = playerLives;
    }

    public void RespawnPlayer()
    {
        if (playerLives > 0)
        {
            Instantiate(player, player.transform.position, player.transform.rotation);
            playerLives--;
        }
        else
        {
            Invoke("GameOver", 3f);
        }
    }

    private void GameOver()
    {
        sm.GameOverMessage();
        sm.UpdateHighScore();
        sessionRunning = false;
        playerLives = playerLivesAtStart;
        Invoke("ReturnToMainMenu", 3f);
    }

    private void ReturnToMainMenu()
    {
        lm.LoadLevel("MainMenu");
    }
}