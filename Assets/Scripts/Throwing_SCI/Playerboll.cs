using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playerboll : MonoBehaviour
{

    [SerializeField] private Cooldown cooldown;

    [SerializeField]
    GameObject Ball;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {


            Instantiate(Ball, transform.position + new Vector3(1, 2), Quaternion.identity);

        }


    }

}
