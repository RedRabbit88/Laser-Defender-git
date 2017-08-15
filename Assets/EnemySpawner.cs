using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform enemies;
    public Transform enemy1;


    private void Start()
    {
        Instantiate(enemy1, enemies);
    }
}
