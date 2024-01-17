using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController_Stationary : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float movementSpeed = 2f;
    public float hearingRange = 10f;
    public LayerMask playerLayer;

    private Transform player;
    private bool playerSpotted;
    private Vector3 ballDestroyedPosition;
    private bool ballLandedInRange;

    private bool reachedBallPosition = false;
    private PlayerMovement playermovement; // Add reference to PlayerMovement script
    public static bool BallOnTheMove = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playermovement = player.GetComponent<PlayerMovement>(); // Get reference to PlayerMovement script
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if the player is within the detection radius
        if (distanceToPlayer <= detectionRadius)
        {
            // Spot the player
            SpotPlayer();
        }

        // If the ball has landed within the hearing range
        if (ballLandedInRange)
        {
            MoveTowardsBallDestroyedPosition();
        }
    }

    private void SpotPlayer()
    {
        if (playermovement != null && playermovement.hiding)
        {
            return; // Don't spot the player if hiding
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, detectionRadius, playerLayer);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            // Player is spotted
            playerSpotted = true;
            RestartScene();
        }
    }

    private void RestartScene()
    {
        // Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void MoveTowardsBallDestroyedPosition()
    {
        if (ballDestroyedPosition != Vector3.zero && !reachedBallPosition)
        {
            Vector2 direction = (ballDestroyedPosition - transform.position).normalized;

            // Introduce a stopping distance
            float stoppingDistance = 1.0f;
            float distanceToBall = Vector2.Distance(transform.position, ballDestroyedPosition);

            // Set a maximum speed
            float maxSpeed = 5.0f;

            if (distanceToBall > stoppingDistance)
            {
                // Apply speed based on distance
                float speed = Mathf.Min(movementSpeed, maxSpeed);
                transform.Translate(direction * speed * Time.deltaTime);
            }
            else
            {
                // If the enemy is close enough to the ball, stop moving and set the flag
                reachedBallPosition = true;
            }
        }
    }


private void OnDrawGizmosSelected()
    {
        // Draw both detection radius and hearing range as wire spheres in the scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, hearingRange);
    }

    // Added method to set the ball destroyed position
    public void SetBallDestroyedPosition(Vector3 position)
    {
        ballDestroyedPosition = position;
        reachedBallPosition = false; // Reset the flag when a new ball is thrown
        BallOnTheMove = true; // Set the flag to indicate the ball is on the move

        // Check if the ball has landed within the hearing range
        float distanceToBall = Vector2.Distance(transform.position, ballDestroyedPosition);
        if (distanceToBall <= hearingRange)
        {
            ballLandedInRange = true;
        }
    }
}
