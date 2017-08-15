using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string sceneString)
    {
        int sceneID;

        if (int.TryParse(sceneString, out sceneID))
        {
            // Load scene by ID
            SceneManager.LoadSceneAsync(sceneID);
        }
        else
        {
            // Load scene by String
            SceneManager.LoadSceneAsync(sceneString);
        }
            
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}