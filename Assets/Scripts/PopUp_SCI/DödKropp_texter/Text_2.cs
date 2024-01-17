using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_2 : MonoBehaviour
{
    public GameObject PopUp_2;
    bool PlayerOnBody = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerOnBody == true)
        {
            PopUp_2.SetActive(true);
        }

        if (PlayerOnBody == false)
        {
            PopUp_2.SetActive(false);
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