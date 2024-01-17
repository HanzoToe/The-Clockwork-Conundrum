using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ballcon : MonoBehaviour
{
    public float power = 10f;

    public GameObject player;
    Rigidbody2D rb;
    LineRenderer lr;

    public static bool BallOnTheMove = false;
    public static bool BallDestroyed = false; // Added variable to track if the ball is destroyed

    Vector2 DragStartPos;

    public PlayerMovement playerMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (BallOnTheMove == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rb.gravityScale = 0;
                playerMovement.enabled = false;
            }

            if (Input.GetMouseButton(0))
            {
                Vector2 DragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 _velocity = (DragEndPos - DragStartPos) * power;

                Vector2[] trajectory = Plot(rb, (Vector2)transform.position, _velocity, 500);

                lr.positionCount = trajectory.Length;

                Vector3[] positions = new Vector3[trajectory.Length];
                for (int i = 0; i < trajectory.Length; i++)
                {
                    positions[i] = trajectory[i];
                }
                lr.SetPositions(positions);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Vector2 DragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 _velocity = (DragEndPos - DragStartPos) * power;

                rb.velocity = _velocity;
                rb.gravityScale = 3;
                BallOnTheMove = true;
            }
        }
    }

    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    {
        Vector2[] results = new Vector2[steps];
        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * 3 * timestep * timestep;
        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;

        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") || collision.CompareTag("wall"))
        {
            new WaitForSeconds(2);
            Destroy(gameObject);
            BallOnTheMove = false;
            BallDestroyed = true; // Set BallDestroyed to true when the ball is destroyed

            playerMovement.enabled = true;
            Playerboll.freezeplayer = false;

            if (collision.CompareTag("ground"))
            {
                // Store the ball's destroyed position in enemies
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    EnemyController_Stationary enemyController = enemy.GetComponent<EnemyController_Stationary>();
                    if (enemyController != null)
                    {
                        enemyController.SetBallDestroyedPosition(transform.position);
                    }
                }
            }
        }
    }
}
