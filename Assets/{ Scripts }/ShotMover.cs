using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMover : MonoBehaviour {

    public string target;
    public float shotSpeed = 1f;
    public int shotPower;
    public GameObject hitExplosion;
    private AudioManager am;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        am = FindObjectOfType<AudioManager>();
        rb.velocity = transform.up * shotSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == target)
        {
            if (other.tag == "Enemy") {
                other.transform.parent.GetComponent<EnemyController>().DestroyShip(shotPower); }
            else if (other.tag == "Player") {
                other.transform.parent.GetComponent<PlayerController>().DestroyShip(shotPower); }
            Instantiate(hitExplosion, transform.position, transform.rotation);
            am.ShotHit();
            Destroy(gameObject);
        }
    }
}