using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour {

    public Boundary boundary;
    public GameObject explosion;
    public int enemyHealth;
    public int enemyValue;
    public int startingHealth;
    public float referencePos = 0f;
    public float distanceToAdvance = 1f;
    public bool markForDestruction = false;
    public bool destroyedByPlayer = true;
    private MeshCollider mcol;
    private EnemySpawner es;
    private MoveShip ms;
    private AudioManager am;
    private ScoreManager sm;
    private Animator anim;
    Camera cam;


    private void Awake()
    {
        mcol = transform.GetComponentInChildren<MeshCollider>();
        es = FindObjectOfType<EnemySpawner>();
        ms = GetComponent<MoveShip>();
        am = FindObjectOfType<AudioManager>();
        sm = FindObjectOfType<ScoreManager>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
        startingHealth = enemyHealth;
    }

    private void Start()
    {
        es.UpdateRefPos();
    }


    private void FixedUpdate()
    {
        // Screen limits
        Vector3 viewMax = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        Vector3 viewMin = cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));

        if (es.inTransit == false)
        {
            // move left
            if (es.moveForward == false && es.moveLeft == true)
            {
                ms.ShipMove(-1f, 0f);
            }

            // move right
            if (es.moveForward == false && es.moveLeft == false)
            {
                ms.ShipMove(1f, 0f);
            }


            // if either boundary reached
            if (es.moveForward == false &&
                    ((transform.position.x <= viewMin.x + boundary.xBuffer && es.moveLeft == true) ||
                    (transform.position.x >= viewMax.x - boundary.xBuffer && es.moveLeft == false))
                )
            {
                es.UpdateRefPos();
                es.moveForward = true;
            }


            // move forward
            if (es.moveForward == true)
            {
                if (transform.position.y > referencePos - distanceToAdvance)
                {
                    ms.ShipMove(0f, -1f);
                }
                else
                {
                    // change direction
                    if (es.moveLeft == true)
                    {
                        es.moveLeft = false;
                    }
                    else if (es.moveLeft == false)
                    {
                        es.moveLeft = true;
                    }

                    es.moveForward = false;
                }
            }
        } else if (es.inTransit == true)
        {
            ms.ShipMove(0f, 0f);
        }
    }


    public void EnemyArrived()
    {
        es.DeclareArrival();
        anim.enabled = false;
        mcol.enabled = true;
    }


    public void DestroyShip(int damage)
    {
        enemyHealth -= damage;

        if(enemyHealth <= 0)
        {
            if(destroyedByPlayer == true)
            {
                sm.ScoreAdd(enemyValue);
            }
            markForDestruction = true;
            es.RemoveFromList();
            am.Explosion();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}