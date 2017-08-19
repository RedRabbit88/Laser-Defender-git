using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpawner : MonoBehaviour {

    public Transform shot;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(shot, transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.25f);
    }
}