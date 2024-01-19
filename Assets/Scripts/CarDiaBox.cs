using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarDiaBox : MonoBehaviour
{
    //Darren

    public DialogueScript dialogueScript;

    private bool dialogueStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueScript.gameObject.SetActive(false);
        dialogueScript.gameObject.SetActive(true);
        dialogueScript.StartDialogue();
        dialogueStarted = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
