using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    public GameObject button;
    public GameObject button2;
    public float cooldown = 22f;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            button.SetActive(true);
            button2.SetActive(true);
        }
    }

   public void quitgame()
    {
        Application.Quit();
    }

   public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
        DestroyAllGameObjects();
    }


    void DestroyAllGameObjects()
    {
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject go in gameObjects)
        {
            if (go.tag != "ExcludeFromDestruction")
            {
                Destroy(go);
            }

        }
    }
}
