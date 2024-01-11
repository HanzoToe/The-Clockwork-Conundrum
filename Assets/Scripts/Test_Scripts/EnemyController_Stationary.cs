using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController_Stationary : MonoBehaviour
{
    public Transform player;
    public float visionRange = 5f;
    public float moveSpeed = 5f;
    public Transform patrolPoint;
    private bool isChasingPlayer = false;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasingPlayer)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            if (Vector2.Distance(transform.position, player.position) < 1f)
            {
                Invoke("Restart", 0.2f);
            }

            if (Vector2.Distance(transform.position, patrolPoint.position) < 1f)
            {
                isChasingPlayer = false;
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, player.position) < visionRange)
            {
                isChasingPlayer = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
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