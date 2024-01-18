
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScript : MonoBehaviour
{
    //Love

    public GameObject pausemenu;
    public static bool isPaused;
    public GameObject player;



    void Start()
    {
        pausemenu.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player"); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
        Destroy(player);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
