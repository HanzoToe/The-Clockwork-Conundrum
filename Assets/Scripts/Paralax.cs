using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    private float tileSizeX;

    void Start()
    {
        // Assuming all background instances have the same size along the x-axis
        tileSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Move the background instances to the right
        transform.Translate(Vector2.right * scrollSpeed * Time.deltaTime);

        // Check if the background has moved off the screen
        if (transform.position.x > tileSizeX)
        {
            // Move the background to the left to create a seamless loop
            transform.position = new Vector2(-tileSizeX, transform.position.y);
        }
    }
}
