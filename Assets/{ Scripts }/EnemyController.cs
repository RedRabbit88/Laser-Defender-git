using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour {

    public Boundary boundary;
    private EnemySpawner es;
    private MoveShip ms;
    public float previousVPos = 0f;
    Camera cam;

    private void Start()
    {
        es = FindObjectOfType<EnemySpawner>();
        ms = GetComponent<MoveShip>();
        cam = Camera.main;
        previousVPos = transform.position.y;
    }

    private void FixedUpdate()
    {
        // Screen limits
        Vector3 viewMax = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        Vector3 viewMin = cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));


        // move left
        if (es.moveLeft == true && es.moveForward == false) {
            ms.ShipMove(-1f, 0f); }

        // move right
        if (es.moveLeft == false && es.moveForward == false) {
            ms.ShipMove(1f, 0f); }


        // if either boundary reached
        if (es.moveForward == false &&
                ((transform.position.x <= viewMin.x + boundary.xBuffer && es.moveLeft == true) ||
                (transform.position.x >= viewMax.x - boundary.xBuffer && es.moveLeft == false))
            )
        {
            es.moveForward = true;
        }


        // move forward
        if (es.moveForward == true)
        {
            if(transform.position.y > previousVPos - 1)
            {
                // transform.position = new Vector3(transform.position.x, previousVPos - 1f, 0f);
                ms.ShipMove(0f, -1f);
                // Debug.Log("MOVING FORWARD!: " + Time.fixedTime);
            }
            else
            {
                // change direction
                if (es.moveLeft == true) {
                    es.moveLeft = false;
                } else if (es.moveLeft == false) {
                    es.moveLeft = true; }

                Debug.Log("setting previous VPos to: " + previousVPos);
                previousVPos = transform.position.y;
                
                es.moveForward = false;
            }
        }
    }

}