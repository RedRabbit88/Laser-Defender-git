using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform enemy1;
    public float distanceToEdge;
    public bool moveLeft = false;
    public bool moveForward = false;

    private void Start()
    {
        foreach(Transform pos in transform)
        {
            Instantiate(enemy1, pos.transform.position, Quaternion.identity, pos.transform);
        }
    }

    public void UpdateRefPos()
    {
        foreach(EnemyController enemy in transform)
        {
            enemy.referencePos = enemy.transform.position.y;
        }
    }
}