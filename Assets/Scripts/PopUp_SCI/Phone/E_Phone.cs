using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Phone : MonoBehaviour
{
    //Darren


    public GameObject PopUp_E;
    
    // Start is called before the first frame update
    void Start()
    {
        PopUp_E.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PopUp_E.SetActive(false);
        }
    }
}
