using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour {

    public Boundary boundary;
    public float referencePos = 0f;
    public float distanceToAdvance = 1f;
    private EnemySpawner es;
    private MoveShip ms;
    Camera cam;

    private void Start()
    {
        es = FindObjectOfType<EnemySpawner>();
        ms = GetComponent<MoveShip>();
        cam = Camera.main;
        es.UpdateRefPos();
    }

    private void FixedUpdate()
    {
        // Screen limits
        Vector3 viewMax = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        Vector3 viewMin = cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));


        // move left
        if (es.moveForward == false && es.moveLeft == true) {
            ms.ShipMove(-1f, 0f); }

        // move right
        if (es.moveForward == false && es.moveLeft == false) {
            ms.ShipMove(1f, 0f); }


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
            if(transform.position.y > referencePos - distanceToAdvance)
            {
                ms.ShipMove(0f, -1f);
            }
            else
            {
                // change direction
                if (es.moveLeft == true) {
                    es.moveLeft = false;
                } else if (es.moveLeft == false) {
                    es.moveLeft = true; }

                es.moveForward = false;
            }
        }
    }
}