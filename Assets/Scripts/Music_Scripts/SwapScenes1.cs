using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes1 : MonoBehaviour
{
    void Update()
    {
        //Test till railyard ambiance
        if (SceneManager.GetActiveScene().name == "Train_Scene")
            BGmusic.instance.GetComponent<AudioSource>().Play();

    }
}

