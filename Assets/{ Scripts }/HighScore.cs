using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    private SessionManager session;
    private Text highScore;

    private void Awake()
    {
        session = FindObjectOfType<SessionManager>();
        highScore = GetComponent<Text>();
    }

    void Start () {
        highScore.text = "high score: " + session.highScore.ToString();
	}
}