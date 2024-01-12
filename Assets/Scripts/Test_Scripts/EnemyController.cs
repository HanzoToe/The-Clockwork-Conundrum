using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolpoints;
    public float movespeed = 5f;
    private bool playerdetected = false;
    private int currentPatrolIndex = 0;
    private Rigidbody2D rb;
    private bool isChasingPlayer = false;
    private Rigidbody2D playerRigidbody;
    private float dirX;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        dirX = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerdetected && !isChasingPlayer)
        {
            isChasingPlayer = true;
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolpoints.Length; // Update current patrol index
        }

        if (isChasingPlayer)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.AddForce(direction * movespeed, ForceMode2D.Force);

            if (Vector2.Distance(transform.position, player.position) < 1f)
            {
                Invoke("Restart", 0.2f);
            }

            if (playerRigidbody.velocity.y <= 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, playerRigidbody.velocity.y);
            }
        }
        else
        {
            Transform currentPatrolPoint = patrolpoints[currentPatrolIndex];
            Vector2 direction = (currentPatrolPoint.position - transform.position).normalized;
            rb.velocity = direction * movespeed;

            if (Vector2.Distance(transform.position, currentPatrolPoint.position) < 1f)
            {
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolpoints.Length;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerdetected = true;
        }

        

    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerdetected = false;
            isChasingPlayer = false;
            rb.velocity = Vector2.zero;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}
