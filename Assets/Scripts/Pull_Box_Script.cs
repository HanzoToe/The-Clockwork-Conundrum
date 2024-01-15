using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pull_Box_Script : MonoBehaviour
{
    private bool canPull = false;
    private GameObject boxToPull;
    public Transform pullPoint;
    public Transform boundaryPoint;
    public GameObject PressQUI;

    private void Start()
    {
        // Initial setup to find UI GameObject
        FindUIElement();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for UI GameObject in case it changes scenes
        FindUIElement();

        pullPoint = GameObject.FindGameObjectWithTag("BoxBoundry").transform;
        boundaryPoint = GameObject.FindGameObjectWithTag("BoxBoundry").transform;

        if (canPull && Input.GetKey(KeyCode.Q))
        {
            PullBox();
        }
    }

    private void FindUIElement()
    {
        // Find the Canvas GameObject in the currently active scene
        Canvas canvas = FindObjectOfType<Canvas>();

        if (canvas != null)
        {
            // Assuming your UI GameObject is a direct child of the Canvas
            Transform uiElementTransform = canvas.transform.Find("PressQUI");

            if (uiElementTransform != null)
            {
                PressQUI = uiElementTransform.gameObject;
                Debug.Log("UI Element found!");
                // You can activate it here if needed
                // PressQUI.SetActive(true);
            }
            else
            {
                Debug.LogError("UI Element not found. Check the name or tag.");
            }
        }
        else
        {
            Debug.LogError("Canvas not found.");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            if (PressQUI != null)
            {
                PressQUI.SetActive(true);
            }

            canPull = true;
            boxToPull = collision.gameObject;
            Debug.Log("Can pull");
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            if (PressQUI != null)
            {
                PressQUI.SetActive(false);
            }

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

            if (PressQUI != null)
            {
                PressQUI.SetActive(false);
            }
        }
    }
}