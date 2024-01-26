using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    void Update()
    {
        

        if (SceneManager.GetActiveScene().name == "Office")
            BGmusic.instance.GetComponent<AudioSource>().Pause();
        if (SceneManager.GetActiveScene().name == "Train_Inside")
            BGmusic.instance.GetComponent<AudioSource>().Play();
        
        //BGmusic.instance.GetComponent<AudioSource>().Play();

    }
}
