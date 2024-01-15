using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController_Stationary : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask playerLayer;

    private Transform player;
    private bool playerSpotted;

    public PlayerMovement playermovement; 


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playermovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); 
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
            // Check if the player is within the detection radius
            if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
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
    }

    private void RestartScene()
    {
        // Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the detection radius as a wire sphere in the scene view
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.forward, detectionRadius);
    }
}

