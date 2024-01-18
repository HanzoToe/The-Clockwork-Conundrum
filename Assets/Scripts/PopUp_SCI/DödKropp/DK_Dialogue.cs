using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class DK_Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public float textspeed;
    public string[] lines;
    private int index;
    public CanvasGroup canvasGroup;
    FadeInOut fadeinout;


    //Darren

    // Start is called before the first frame update
    void Start()
    {
        fadeinout = GetComponent<FadeInOut>();
        textcomponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textcomponent.text == lines[index])
            {
                Nextline();
            }
            else
            {
                StopAllCoroutines();
                textcomponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        textcomponent.text = string.Empty;
        StartCoroutine(Typeline());
    }

    IEnumerator Typeline()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void Nextline()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textcomponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
            fadeinout.FadeOut();
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        // Wait for the fade-out animation to complete
        yield return new WaitForSeconds(2f);

        // Load the new scene
        SceneManager.LoadScene(1);
    }
}
