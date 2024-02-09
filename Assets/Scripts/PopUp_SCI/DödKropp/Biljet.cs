using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biljet : MonoBehaviour
{

    // Daniel Antunes Goncalves

    PlayerMovement PM;

    public DK_Dialogue dialogueScript;

    public static bool FreezePlayer = false;
    bool BeginDialogue = false;
    
    public GameObject biljet;
    bool PlayerOnBody = false;

    private bool dialogueStarted = false;

    public GameObject dialoguebox;

    public GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectWithTag("Player"); 
        dialogueScript.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerOnBody == true && Input.GetKey(KeyCode.E))
        {
            biljet.SetActive(true);

            FreezePlayer = true;

            BeginDialogue = true;

            player.SetActive(false);
        }

        if (BeginDialogue == true && dialogueStarted == false)
        {
            dialogueScript.gameObject.SetActive(true);
            dialogueScript.StartDialogue();
            dialogueStarted = true;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerOnBody = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerOnBody = false;
        }


    }
}
