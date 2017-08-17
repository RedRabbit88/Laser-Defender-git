using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xBuffer, yBufferTop, yBufferBottom;
}


public class MoveShip : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 10f;
    public float boost = 1.75f;
    public float rotationMultiplier = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Rotation
        transform.rotation = Quaternion.Euler(0f, 0f + (-rb.velocity.x * rotationMultiplier), 0f);
    }

    public void ShipMove(float h, float v)
    {
        rb.velocity = new Vector3(h, v, 0f) * speed * Time.deltaTime;
    }

    public void ShipBoost(float h, float v)
    {
        rb.velocity = new Vector3(h, v, 0f) * (speed * boost) * Time.deltaTime;
    }
}