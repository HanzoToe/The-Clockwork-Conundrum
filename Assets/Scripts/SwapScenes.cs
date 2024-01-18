using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    void Update()
    {
        

        if (SceneManager.GetActiveScene().name == "Train_Scene")
            BGmusic.instance.GetComponent<AudioSource>().Stop();
        
        //BGmusic.instance.GetComponent<AudioSource>().Play();

    }
}
