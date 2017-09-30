using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Boundary boundary;
    public GameObject explosion;
    public int playerHealth;
    public int playerLives;
    private MoveShip ms;
    private GameObject gameManager;
    private AudioManager am;
    private ScoreManager sm;
    private SessionManager session;
    Camera cam;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        am = gameManager.GetComponent<AudioManager>();
        sm = gameManager.GetComponent<ScoreManager>();
        session = gameManager.GetComponent<SessionManager>();
        ms = GetComponent<MoveShip>();
        cam = Camera.main;

        if(session.sessionRunning == false)
        {
            sm.InitializeScore();
            session.sessionRunning = true;
        }

        sm.LivesUpdate(session.playerLives);
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
        // Movement (Player)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            ms.ShipBoost(h, v);
        }
        else
        {
            ms.ShipMove(h, v);
        }
    }

    public void DestroyShip(int damage)
    {
        playerHealth -= damage;

        if(playerHealth <= 0)
        {
            am.Explosion();
            session.RespawnPlayer();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}