using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    FadeInOut fade;
    public GameObject pressEUI;
    public GameObject player;
    public GameObject door;
    public float timebeforenextscene;
    public bool playerisatthedoor;
    
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerisatthedoor)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(timebeforenextscene);

        fade.Fade_in = true;
        yield return new WaitForSeconds(1);

        // Destroy all game objects in the scene
        DestroyAllGameObjects();

        // Load the new scene
        SceneManager.LoadScene(10);
    }

    void DestroyAllGameObjects()
    {
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject go in gameObjects)
        {
            // Exclude certain objects from destruction if needed
            if (go.tag != "ExcludeFromDestruction")
            {
                Destroy(go);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && BoxInteraction.OnBox)
        {
            playerisatthedoor = true;
            pressEUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerisatthedoor = false;
        pressEUI.SetActive(false);
    }
}

