using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Phone : MonoBehaviour
{
    public GameObject PopUp_Space;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PopUp_Space.SetActive(true);
        }

        if (PopUp_Space)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PopUp_Space.SetActive(false);
            }
        }
    }
}
