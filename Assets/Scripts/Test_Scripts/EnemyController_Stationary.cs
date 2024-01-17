using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController_Stationary : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float movementSpeed = 2f; // Added movement speed
    public float hearingRange = 10f; // Added hearing range
    public LayerMask playerLayer;

    private Transform player;
    private bool playerSpotted;

    public PlayerMovement playermovement;
    public Rigidbody2D rb;
    private Vector3 ballDestroyedPosition; // Added variable to store ball destroyed position

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playermovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("enemy"), LayerMask.NameToLayer("player"));
    }

    private void Update()
    {
        if (playermovement.hiding)
        {
            playerSpotted = false;
            detectionRadius = 0f;
        }
        else
        {
            detectionRadius = 4f;
        }

        if (!playerSpotted)
        {
            // Check if the player is within the detection radius or hearing range
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= detectionRadius || (distanceToPlayer <= hearingRange && Ballcon.BallOnTheMove))
            {
                // Check if there are no obstacles between the guard and the player
                RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, detectionRadius, playerLayer);
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    // Player is spotted
                    playerSpotted = true;
                    RestartScene();
                }
            }
        }

        // Move towards the ball's destroyed position when spotted
        if (ballDestroyedPosition != Vector3.zero)
        {
            MoveTowardsBallDestroyedPosition();
        }
    }

    private void RestartScene()
    {
        // Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void MoveTowardsBallDestroyedPosition()
    {
        // Calculate direction towards the ball's destroyed position
        Vector2 direction = (ballDestroyedPosition - transform.position).normalized;
        rb.MovePosition(rb.position + direction * movementSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw both detection radius and hearing range as wire spheres in the scene view
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.forward, detectionRadius);

        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, Vector3.forward, hearingRange);
    }

    // Added method to set the ball destroyed position
    public void SetBallDestroyedPosition(Vector3 position)
    {
        ballDestroyedPosition = position;
    }
}



