using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes1 : MonoBehaviour
{
    
    void Update()
    {


        if (SceneManager.GetActiveScene().name == "Train_Inside")
            BGmusic.instance.GetComponent<AudioSource>().Pause();

        if (SceneManager.GetActiveScene().name == "Train_Scene ")
            BGmusic.instance.GetComponent<AudioSource>().Play();

        if (SceneManager.GetActiveScene().name == "Train_Scene_1 ")
            BGmusic.instance.GetComponent<AudioSource>().Play();

        //BGmusic.instance.GetComponent<AudioSource>().Play();

    }
}

