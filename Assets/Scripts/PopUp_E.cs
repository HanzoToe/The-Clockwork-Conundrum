using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject PopUp_E;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PopUp_E.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PopUp_E.SetActive(false);
    }

}