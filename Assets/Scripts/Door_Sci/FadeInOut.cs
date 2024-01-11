using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup CanvasGroup;

    public bool Fade_in = false;
    public bool Fade_out = false;

    public float TimeToFade;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Fade_in == true)
        {
            if (CanvasGroup.alpha < 1)
            {
                CanvasGroup.alpha += TimeToFade * Time.deltaTime;
                if (CanvasGroup.alpha >= 1)
                {
                    Fade_in = false;
                }
            }
        }

        if (Fade_out == true)
        {
            if (CanvasGroup.alpha >= 0)
            {
                CanvasGroup.alpha -= TimeToFade * Time.deltaTime;
                if (CanvasGroup.alpha == 0)
                {
                    Fade_out = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        Fade_in = true;
    }

    public void FadeOut()
    {
        Fade_out = true;
    }
}
