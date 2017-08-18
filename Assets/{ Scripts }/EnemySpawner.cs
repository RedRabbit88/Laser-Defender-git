using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy1;
    public float distanceToEdge;
    public bool moveLeft = false;
    public bool moveForward = false;
    private List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        foreach(Transform pos in transform)
        {
            GameObject enemy = Instantiate(enemy1, pos.transform.position, Quaternion.identity, pos.transform) as GameObject;
            enemies.Add(enemy);
        }
    }

    // Updates reference position for advancement of all enemy ships in wave
    public void UpdateRefPos()
    {
        int listCount = enemies.Count;

        while (listCount > 0)
        {
            enemies[listCount - 1].GetComponent<EnemyController>().referencePos = enemies[listCount - 1].transform.position.y;
            listCount--;
        }
    }
}