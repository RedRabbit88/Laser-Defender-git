using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    private int scoreCount;


	void Start () {
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
}