using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneParameters : MonoBehaviour {
    private AudioManager am;
    private string sceneName;

    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        sceneName = SceneManager.GetActiveScene().name;
    }

    private void Start ()
    {
        if (sceneName == "MainMenu")
        {
            Debug.Log("MainMenu is loaded");
            am.PlayTrack(1);
        }
        else if (sceneName == "Game")
        {
            Debug.Log("Game is loaded");
            am.PlayTrack(0);
        }
        else
        {
            Debug.Log("Unspecified scene loaded.  Of Name: " + sceneName);
        }
	}
}
