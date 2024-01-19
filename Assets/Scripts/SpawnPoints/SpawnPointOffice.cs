using UnityEngine;

public class SpawnPointOffice : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public Transform OfficespawnPoint;
    public Vector3 newSize = new Vector3(0.9942188f, 0.9004575f, 1.0f);

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        DontDestroyOnLoad(player);



        // If player object is found, set its position to the spawn point
        if (player != null)
        {
            OfficespawnPoint = GameObject.Find("OfficeSpawnPoint").transform;
            player.transform.position = OfficespawnPoint.position;
            player.transform.localScale = newSize;

        }
        else
        {
            Debug.LogWarning("Player object not found in the scene.");
        }

        // Find or assign the spawn point in the new scene


        // Set the player's position to the spawn point

    }
}