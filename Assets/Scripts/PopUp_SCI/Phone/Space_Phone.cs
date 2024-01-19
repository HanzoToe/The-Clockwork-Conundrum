using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Phone : MonoBehaviour
{
    //Daniel Antunes Goncalves

    public GameObject PopUp_Space;

    // Start is called before the first frame update
    void Start()
    {
        PopUp_Space.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (PopUp_Space)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PopUp_Space.SetActive(false);
            }
        }
    }
}
