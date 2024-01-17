using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
    

 
{
    [SerializeField] GameObject PauseMenu;
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        //Timescale 0 betyder att spelet är pausat
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //Timescale 1 betyder att spelet kör i standard hastighet
    }
    public void Return()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }
    
}
