using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : MonoBehaviour {
    private LevelManager lm;

	// Use this for initialization
	void Start () {
        lm = FindObjectOfType<LevelManager>();
        lm.LoadLevel("MainMenu");
	}	
}