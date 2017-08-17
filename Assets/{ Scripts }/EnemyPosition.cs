﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}