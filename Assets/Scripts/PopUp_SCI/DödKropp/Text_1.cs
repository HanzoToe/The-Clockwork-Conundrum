using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_1 : MonoBehaviour
{
    public GameObject PopUp_1;
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
            PopUp_1.SetActive(false);
        }

        if (PlayerOnBody == false)
        {
            PopUp_1.SetActive(true);
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
