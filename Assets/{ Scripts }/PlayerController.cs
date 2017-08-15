using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xBuffer, yBufferTop, yBufferBottom;
}


public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public float boost = 1.75f;
    public float rotationMultiplier = 1f;
    public Boundary boundary;
    private Rigidbody rb;
    Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        Debug.Log("Rotation of " + gameObject.name + ": " + transform.rotation.eulerAngles.z);
    }

    private void Update()
    {
        // Screen limits
        Vector3 viewMax = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        Vector3 viewMin = cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));

        // Position
        float positionX = Mathf.Clamp(
            transform.position.x,
            viewMin.x + boundary.xBuffer,
            viewMax.x - boundary.xBuffer);
        float positionY = Mathf.Clamp(
            transform.position.y,
            viewMin.y + boundary.yBufferBottom,
            viewMax.y - boundary.yBufferTop);
        transform.position = new Vector3(positionX, positionY, 0f);
    }

    private void FixedUpdate()
    {
        // Movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rb.velocity = new Vector3(h, v, 0f) * (speed * boost) * Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector3(h, v, 0f) * speed * Time.deltaTime;
        }

        // Rotation
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            0f + (-rb.velocity.x * rotationMultiplier),
            transform.rotation.eulerAngles.z);
    }
}