using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public Transform spawnPoint; 

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        DontDestroyOnLoad(player);



        // If player object is found, set its position to the spawn point
        if (player != null)
        {
            spawnPoint = GameObject.Find("SpawnPoint").transform;
            player.transform.position = spawnPoint.position;
        }
        else
        {
            Debug.LogWarning("Player object not found in the scene.");
        }

        // Find or assign the spawn point in the new scene
        

        // Set the player's position to the spawn point

    }
}