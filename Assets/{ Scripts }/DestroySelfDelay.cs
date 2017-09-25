using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfDelay : MonoBehaviour {
    public float destroyAfter;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, destroyAfter);
	}
}