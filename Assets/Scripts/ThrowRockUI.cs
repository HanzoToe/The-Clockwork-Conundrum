using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRockUI : MonoBehaviour
{
    public GameObject ThrowUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && PickupObject.KeyPickedUp == true)
        {
            ThrowUI.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ThrowUI.SetActive(false);
        }
    }
}
