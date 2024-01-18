using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biljet : MonoBehaviour
{

    // Daniel Antunes Goncalves

    PlayerMovement PM;

    public static bool FreezePlayer = false;
    public static bool CancelScript = false;
    
    public GameObject biljet;
    bool PlayerOnBody = false;
    
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerOnBody == true && Input.GetKey(KeyCode.E))
        {
            biljet.SetActive(true);

            FreezePlayer = true;

        }

        if (CancelScript == true)
        {
            PM.enabled = false;
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
