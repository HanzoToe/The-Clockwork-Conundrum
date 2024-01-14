using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull_Box_Script : MonoBehaviour
{

    private bool canPull = false;
    private GameObject boxToPull;
    public Transform pullPoint;
    public Transform boundaryPoint;
    public GameObject PressQUI;

    // Update is called once per frame
    void Update()
    {
        if (canPull && Input.GetKey(KeyCode.Q))
        {
            PullBox();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            PressQUI.SetActive(true);
            canPull = true;
            boxToPull = collision.gameObject;
            Debug.Log("Can pull");
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            PressQUI.SetActive(false);
            canPull = false;
            boxToPull = null;
            Debug.Log("Can't pull");
        }
    }

    private void PullBox()
    {
        // Calculate the direction from pull point to the box
        Vector3 pullDirection = pullPoint.position - boxToPull.transform.position;
        pullDirection.Normalize();

        // Calculate the distance between the box and the boundary point
        float distanceToBoundary = Vector3.Distance(boxToPull.transform.position, boundaryPoint.position);

        // Set the maximum distance the box can be pulled
        float maxPullDistance = 5f;

        // Move the box towards the pull point
        if (distanceToBoundary > maxPullDistance)
        {
            boxToPull.transform.position += pullDirection * Time.deltaTime * 5f;
        }
        else
        {
            Rigidbody2D boxRigidbody = boxToPull.GetComponent<Rigidbody2D>();
            if (boxRigidbody != null)
            {
                boxRigidbody.velocity = Vector2.zero; // Set velocity to zero to freeze the box
                boxRigidbody.isKinematic = true; // Set isKinematic to true to prevent further physics interactions
            }
            PressQUI.SetActive(false);
        }
    }
}