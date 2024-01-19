using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePopUp : MonoBehaviour
{

    public GameObject Hide_PopUp;
    bool OnTrashCan = false;
    bool hiding = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hiding == false)
        {
            if (OnTrashCan == true)
            {
                Hide_PopUp.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    hiding = true;
                }
            }
        }

        if (hiding == true)
        {
            Hide_PopUp.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            hiding = false;
        }
        
        if (OnTrashCan == false)
        {
            Hide_PopUp.SetActive(false);

            hiding = false;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnTrashCan = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnTrashCan = false;
        }
    }
}
