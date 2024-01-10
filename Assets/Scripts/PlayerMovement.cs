using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private float movement;
    public float jump = 2f;
    private bool isgrounded = false;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleJump();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

   private void HandleMovement()
    {
        movement = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(movement * speed * 2, rb.velocity.y);
        }
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump); 
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            isgrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            isgrounded = false; 
        }
    }
}
