using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    

    public float power = 10f;


    Rigidbody2D rb;

    LineRenderer lr;


    Vector2 DragStartPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.gravityScale = 0;

        }

        if (Input.GetMouseButton(0))
        {
            Vector2 DragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _velocity = (DragEndPos - DragStartPos) * power;

            Vector2[] trajectory = Plot(rb, (Vector2)transform.position, _velocity, 500);

            lr.positionCount = trajectory.Length;


            Vector3[] positions = new Vector3[trajectory.Length];
            for (int i = 0; i < trajectory.Length; i++)
            {
                positions[i] = trajectory[i];



            }
            lr.SetPositions(positions);




        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 DragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _velocity = (DragEndPos - DragStartPos) * power;

            rb.velocity = _velocity;
            rb.gravityScale = 3;

            
        }



    }

    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    {

        Vector2[] results = new Vector2[steps];


        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * 3 * timestep * timestep;

        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;

        for (int i = 0; i < steps; i++)
        {

            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;



        }


        return results;



    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        new WaitForSeconds(2);
        Destroy(gameObject);


    }
}
