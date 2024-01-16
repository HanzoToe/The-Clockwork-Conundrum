using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 5f;
    private float movement;
    public float jump = 2f;
    private bool isgrounded = false;

    public Rigidbody2D rb;
    private float dirX;
    private SpriteRenderer rend;
    public bool canHide = false;
    public bool hiding = false;

    bool facingright = true; 
    public Animator animator;

    float OriginalSpeed;
    float OriginalJump;




    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        OriginalSpeed = speed;
        OriginalJump = jump; 

    }

    // Update is called once per frame
    private void Update()
    {
        CanHide();
        HandleJump();

        if (Playerboll.freezeplayer)
        {
            speed = 0f;
            jump = 0f;
            animator.SetFloat("IsWalking", -1f);
        }
        else
        {
            speed = OriginalSpeed;
            jump = OriginalJump; 
        }
        
    }

    private void FixedUpdate()
    {
        Hiding();
        HandleMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cover"))
        {
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Cover"))
        {
            canHide = false;
        }
    }

    private void HandleMovement()
    {
        movement = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("IsWalking", Mathf.Abs(movement));
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
        {
            if (movement > 0 && facingright)
            {
                Flip();
            }
            else if (movement < 0 && !facingright)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
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

    public void CanHide()
    {
        dirX = Input.GetAxisRaw("Horizontal") * speed;

        if (canHide)
        {
            if (canHide)
            {
                
                Physics2D.IgnoreLayerCollision(8, 9, true);
                rend.sortingOrder = -1;
                hiding = true;
            }
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            rend.sortingOrder = 2;
            hiding = false;
        }

    }

    public void Hiding()
    {
        if (!hiding)
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;
    }
}
