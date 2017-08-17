using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour {

    public Boundary boundary;
    public float referencePos = 0f;
    private EnemySpawner es;
    private MoveShip ms;
    private Text text;
    Camera cam;

    private void Start()
    {
        es = FindObjectOfType<EnemySpawner>();
        ms = GetComponent<MoveShip>();
        cam = Camera.main;
        text = GetComponentInChildren<Text>();
        es.UpdateRefPos();
    }

    private void Update()
    {
        DisplayPositionText();
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
            referencePos = transform.position.y;
            es.moveForward = true;
        }


        // move forward
        if (es.moveForward == true)
        {
            if(transform.position.y > referencePos - 1)
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

                
                DisplayPositionText();

                es.moveForward = false;
            }
        }
    }

    void DisplayPositionText()
    {
        text.text = "ref Y pos: " + referencePos + "\n" +
            "current pos: " + transform.position.y;
    }
}