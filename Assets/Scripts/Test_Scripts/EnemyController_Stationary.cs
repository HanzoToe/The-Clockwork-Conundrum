using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController_Stationary : MonoBehaviour
{
    //Darren

    float stoppingDistance = 3f;
    public float movementSpeed = 2f;
    public float hearingRange = 10f;
    public LayerMask playerLayer;

    public Transform player;
    private bool playerSpotted;
    private Vector3 ballDestroyedPosition;
    private bool ballLandedInRange;

    private bool reachedBallPosition = false;
    private PlayerMovement playermovement; // Add reference to PlayerMovement script
    public static bool BallOnTheMove = false;

    public Animator animator;
    bool facingright = true;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playermovement = player.GetComponent<PlayerMovement>(); // Get reference to PlayerMovement script
    }

    private void Update()
    {

        // If the ball has landed within the hearing range
        if (ballLandedInRange)
        {
            MoveTowardsBallDestroyedPosition();
            
        }

    }

    private void MoveTowardsBallDestroyedPosition()
    {
        if (ballDestroyedPosition != Vector3.zero && !reachedBallPosition)
        {
            Vector2 direction = (ballDestroyedPosition - transform.position).normalized;

            // Introduce a stopping distance
     
            float distanceToBall = Vector2.Distance(transform.position, ballDestroyedPosition);

          

            Rigidbody2D rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component

            if (distanceToBall > stoppingDistance)
            {
                animator.SetFloat("IsWalking", 1f);
                animator.SetBool("Stand", false);

                // Use Rigidbody2D velocity for movement
                rb.velocity = direction * movementSpeed;

                // Adjust the Z position to avoid flying
                transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            }
            else if (distanceToBall <= stoppingDistance)
            {
                // If the enemy is close enough to the ball, stop moving and set the flag
                reachedBallPosition = true;

                // Set velocity to zero to stop the movement
                rb.velocity = Vector2.zero;

                movementSpeed = 0f;

                if (reachedBallPosition)
                {
                    Debug.Log("AT BALL");
                    animator.SetBool("Stand", true);
                    animator.SetFloat("IsWalking", 0f); // Set walking animation to idle
                }
              
            }

            if (movementSpeed > 0 && facingright)
            {
                Flip();
            }
            else if (movementSpeed < 0 && !facingright)
            {
                Flip();
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !playermovement.hiding)
        {
            RestartScene();
        }
    }

    private void RestartScene()
    {
        // Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, hearingRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance); 

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

    private void Flip()
    {
        //Changes where the player is facing
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
    }
}
