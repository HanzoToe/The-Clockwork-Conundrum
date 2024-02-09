using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    void Update()
    {
        //Spelar musik under main menu och phone test

        if (SceneManager.GetActiveScene().name == "Office")
            BGmusic.instance.GetComponent<AudioSource>().Stop();


        //Test till railyard ambiance
        if (SceneManager.GetActiveScene().name == "Train_Scene")
            BGmusic.instance.GetComponent<AudioSource>().Play();
            

    }
}
