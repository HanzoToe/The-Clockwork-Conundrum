using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDialogue : MonoBehaviour
{

    public TextMeshProUGUI textcomponent;
    public float textspeed;
    public string[] lines;
    private int index;

    bool IsShowingMessage = true;



    // Start is called before the first frame update
    void Start()
    {
        textcomponent.text = string.Empty;
        
        StartDialogue();

    }

    // Update is called once per frame
    void Update()
    {
       if (IsShowingMessage == false)
        {
            IsShowingMessage = true; 

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

        yield return new WaitForSeconds(2);
        
        IsShowingMessage = false;
    }

    void Nextline()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textcomponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
    }

    // Googa gaagga

}
