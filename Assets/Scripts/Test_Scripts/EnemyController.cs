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
    private int currentPatrolIndex = 0;
    private Rigidbody2D rb;
    public PlayerMovement playermovement;
    public float tolerance = 2f;
    public float Wait = 0f;
    bool flipped = false;
    public Animator animator; 



    //Darren

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playermovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         if(Wait <= 0)
        {
            animator.SetFloat("IsWalking", Mathf.Abs(1f));
            animator.SetBool("Stand", false);
            flipped = false; 

            //Forces the enemy to go back and forth in between two control points. 
            Transform currentPatrolPoint = patrolpoints[currentPatrolIndex];
            Vector2 direction = (currentPatrolPoint.position - transform.position).normalized;
            rb.velocity = direction * movespeed;

            if (Vector2.Distance(transform.position, currentPatrolPoint.position) < tolerance)
            {
                
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolpoints.Length;
                Wait = 1f;
            
                rb.velocity = Vector2.zero; 
            }

            Debug.Log("Distance to Patrol Point: " + Vector2.Distance(transform.position, currentPatrolPoint.position));
            Debug.Log("Current Patrol Index: " + currentPatrolIndex);
        }
       
        if(Wait > 0)
        {
            animator.SetFloat("IsWalking", -1f);
            animator.SetBool("Stand", true); 
            Wait -= Time.fixedDeltaTime;
           
          if(Wait < 0.01)
            {
                if (!flipped)
                {
                    Flip();
                    flipped = true;
                }
            }
          
            
        }

    }
    
    private void Flip()
    {
      transform.Rotate(0, 180, 0);
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
