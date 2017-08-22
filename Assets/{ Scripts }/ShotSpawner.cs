using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpawner : MonoBehaviour {

    public Transform shot;
    private GameObject parent;

    private void Start()
    {
        parent = transform.parent.gameObject;

        if(parent.tag == "Enemy")
        {
            InvokeRepeating("Fire", Random.Range(0.5f, 2f), Random.Range(1f, 3f));
        }
    }

    private void Update()
    {
        if (parent.tag == "Player" &&
            (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(shot, transform.position, transform.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.25f);
    }
}