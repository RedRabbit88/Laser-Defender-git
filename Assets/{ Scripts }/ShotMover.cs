using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMover : MonoBehaviour {

    public float shotSpeed = 1;
    public string target;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * shotSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == target)
        {
            if (other.tag == "Enemy") {
                other.transform.parent.GetComponent<EnemyController>().DestroyShip(); }
            else if (other.tag == "Player") {
                other.transform.parent.GetComponent<PlayerController>().DestroyShip(); }
            Destroy(gameObject);
        }
    }
}