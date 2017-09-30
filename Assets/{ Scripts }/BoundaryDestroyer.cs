using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour {

    public float boundaryBuffer = 1f;
    private float xmax;
    private float ymax;
    private BoxCollider col;
    private Vector3 colSize = new Vector3(50f, 50f, 50f);

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update () {
        xmax = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
        ymax = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y;

        colSize.x = xmax * 2 + boundaryBuffer;
        colSize.y = ymax * 2 + boundaryBuffer;
        colSize.z = 2f;

        col.size = colSize;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Projectile")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Enemy")
        {
            EnemyController ec = other.GetComponentInParent<EnemyController>();
            ec.destroyedByPlayer = false;
            ec.DestroyShip(ec.startingHealth);
        }
    }
}