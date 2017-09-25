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
        Invoke("NewWave", 2f);
    }

    private void NewWave()
    {
        foreach (Transform pos in transform)
        {
            StartCoroutine(SpawnEnemy(pos));
        }
    }

    IEnumerator SpawnEnemy(Transform pos)
    {
        //yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
        GameObject enemy = Instantiate(enemy1, pos.transform.position, Quaternion.identity, pos.transform) as GameObject;
        enemies.Add(enemy);
        yield return null;
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
                break;
            }
            listCount--;
        }

        // re-evaluate list count & generate new wave if no enemies left.
        listCount = enemies.Count;
        Debug.Log("current listCount: " + listCount);

        if (listCount <= 0)
        {
            Invoke("NewWave", 2f);
        }
    }
}