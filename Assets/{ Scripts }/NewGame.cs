using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    private LevelManager lm;

    private void Awake()
    {
        lm = FindObjectOfType<LevelManager>();
    }

    public void StartNewGame(string levelName)
    {
        lm.LoadLevel(levelName);
    }
}