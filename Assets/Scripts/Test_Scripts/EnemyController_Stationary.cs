using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController_Stationary : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public Transform targetPoint;

    private bool isChasingPlayer = false;
    private bool isReturning = false;
    private Vector2 originalPosition;
    private Rigidbody2D rb;
    private VisionRange visionRangeScript;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
        visionRangeScript = GetComponentInChildren<VisionRange>();
    }

    private void Update()
    {
        if (isChasingPlayer)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            if (Vector2.Distance(transform.position, player.position) < 1f)
            {
                Restart();
            }
        }
        else if (isReturning)
        {
            Vector2 direction = (originalPosition - (Vector2)transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            if (Vector2.Distance(transform.position, originalPosition) < 1f)
            {
                isReturning = false;
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, player.position) < visionRangeScript.visionRange)
            {
                isChasingPlayer = true;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasingPlayer = false;
            rb.velocity = Vector2.zero;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

