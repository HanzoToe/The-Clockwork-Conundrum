using UnityEngine;
using UnityEngine.SceneManagement;

public class KeySpawnManager : MonoBehaviour
{
    public GameObject keyPrefab; // Drag and drop your key prefab in the inspector
 

    private void Start()
    {
        if (!PickupObject.KeyPickedUp)
        {
            // Spawn the key at the position of the invisible GameObject
            GameObject invisibleObject = GameObject.Find("Key"); // Replace "InvisibleKeySpawnPoint" with the actual name of your invisible GameObject
            if (invisibleObject != null)
            {
                SpawnKey(invisibleObject.transform.position);
            }
            else
            {
                Debug.LogError("InvisibleKeySpawnPoint not found!");
            }
        }
    }

    private void SpawnKey(Vector3 spawnPosition)
    {
        // Instantiate the key prefab at the specified position
        GameObject key = Instantiate(keyPrefab, spawnPosition, Quaternion.identity);
    }
}