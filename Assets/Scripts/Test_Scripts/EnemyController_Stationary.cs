using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController_Stationary : MonoBehaviour
{
   
    //Darren 
    public float detectionRadius = 5f;
    public float movementSpeed = 2f;
    public float hearingRange = 10f;
    public LayerMask playerLayer;

    private Transform player;
    private Vector3 ballDestroyedPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //Grab the distance of the playe from the enemy
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if the player is within the detection radius
        if (distanceToPlayer <= detectionRadius)
        {
            // Invoke the restart method
            RestartScene();
        }

        // If the ball is in hearing range and moving
        if (distanceToPlayer <= hearingRange && Ballcon.BallOnTheMove)
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
        //As the method name says lol
        if (ballDestroyedPosition != Vector3.zero)
        {
            Vector2 direction = (ballDestroyedPosition - transform.position).normalized;
            transform.Translate(direction * movementSpeed * Time.deltaTime);
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

    //Set the ball destroyed position
    public void SetBallDestroyedPosition(Vector3 position)
    {
        ballDestroyedPosition = position;
    }
}