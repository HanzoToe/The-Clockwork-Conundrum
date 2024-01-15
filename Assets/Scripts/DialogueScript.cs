using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public float textspeed;
    public string[] lines;
    private int index;


    // Start is called before the first frame update
    void Start()
    {
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
            gameObject.SetActive(false);

            new WaitForSeconds(2);
            SceneManager.LoadScene(1);
        }
    }
}
