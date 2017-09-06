using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy1;
    public float distanceToEdge;
    public bool moveLeft = false;
    public bool moveForward = false;
    private List<GameObject> enemies = new List<GameObject>();
    private GameObject gameManager;

    private void Start()
    {
        // associate / instantiate gameManager ...

        foreach(Transform pos in transform)
        {
            GameObject enemy = Instantiate(enemy1, pos.transform.position, Quaternion.identity, pos.transform) as GameObject;
            enemies.Add(enemy);
        }
        RemoveFromList();
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

    public void RemoveFromList()
    {
        int listCount = enemies.Count;

        while (listCount > 0)
        {
            if (enemies[listCount - 1].GetComponent<EnemyController>().markForDestruction == true)
            {
                enemies.Remove(enemies[listCount - 1]);
                return;
            }
            listCount--;
        }
    }
}