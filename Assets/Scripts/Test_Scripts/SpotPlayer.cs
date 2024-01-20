using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpotPlayer : MonoBehaviour
{
    //Darren

    public float detectionRadius = 5f;
    public LayerMask playerLayer;

    public Transform player;
    private bool playerSpotted;
    private PlayerMovement playermovement; // Add reference to PlayerMovement script
   

 

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
            spotPlayer();
        }


    }

    private void spotPlayer()
    {
        if (playermovement != null && playermovement.hiding)
        {
            return; // Don't spot the player if hiding
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, detectionRadius, playerLayer);
        if (hit.collider != null && hit.collider.CompareTag("Player") && !playermovement.hiding)
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


    private void OnDrawGizmosSelected()
    {
        // Draw both detection radius and hearing range as wire spheres in the scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
