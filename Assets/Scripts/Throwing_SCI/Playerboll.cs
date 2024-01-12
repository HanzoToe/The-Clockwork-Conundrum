using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playerboll : MonoBehaviour
{

    float cooldown = 0;

    [SerializeField]
    GameObject Ball;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && cooldown < 0)
        {


            Instantiate(Ball, transform.position + new Vector3(1, 2), Quaternion.identity);

            cooldown = 5;

        }


    }

}
