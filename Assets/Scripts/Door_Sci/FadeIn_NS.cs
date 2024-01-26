using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn_NextScene : MonoBehaviour
{
    // Daniel Antunes Goncalves
    
    FadeInOut fade;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Fading");
        
        fade = GetComponent<FadeInOut>();
        fade.FadeOut();
    }
}
