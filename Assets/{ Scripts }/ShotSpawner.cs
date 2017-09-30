using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpawner : MonoBehaviour {

    public Transform shot;
    public int shotDamage = 1;
    public float shotRateLimit;
    private float shotTimeSinceLastShot;
    private GameObject parent;
    private EnemySpawner es;
    private AudioManager am;

    private void Awake()
    {
        parent = transform.parent.gameObject;
        am = FindObjectOfType<AudioManager>();
        es = FindObjectOfType<EnemySpawner>();
    }

    private void Start()
    {
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
        if (parent.tag == "Player" || (parent.tag == "Enemy" && es.inTransit == false))
        {
            am.ShotPlayer();
            Transform projectile = Instantiate(shot, transform.position, transform.rotation) as Transform;
            projectile.GetComponent<ShotMover>().shotPower = shotDamage;
        }

        if (parent.tag == "Player") {
            am.ShotPlayer();
        }
        else if (parent.tag == "Enemy" && es.inTransit == false) {
            am.ShotEnemy();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.25f);
    }
}