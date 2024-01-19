using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp_Phone : MonoBehaviour
{
    //Darren

    public Animator animator;
    public DialogueScript dialogueScript;

    private bool dialogueStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("PickUp", true);
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
