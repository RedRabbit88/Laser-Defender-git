using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpawner : MonoBehaviour {

    public Transform shot;
    public int shotDamage = 1;
    public float shotRateLimit;
    private float shotTimeSinceLastShot;
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
            if(shotTimeSinceLastShot <= Time.time - shotRateLimit)
            {
                Fire();
                shotTimeSinceLastShot = Time.time;
            }
        }
    }

    private void Fire()
    {
        Transform projectile = Instantiate(shot, transform.position, transform.rotation) as Transform;
        projectile.GetComponent<ShotMover>().shotPower = shotDamage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.25f);
    }
}