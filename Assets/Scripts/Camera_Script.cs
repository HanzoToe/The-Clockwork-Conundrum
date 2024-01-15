using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public Transform player;
    public BoxCollider2D boundsCollider;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    // Use this for initialization
    void Start()
    {
        minBounds = boundsCollider.bounds.min;
        maxBounds = boundsCollider.bounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.position;
            Vector3 cameraPosition = transform.position;

            cameraPosition.x = Mathf.Clamp(playerPosition.x, minBounds.x, maxBounds.x);
            cameraPosition.y = Mathf.Clamp(playerPosition.y, minBounds.y, maxBounds.y);

            transform.position = cameraPosition;
        }
    }
}
