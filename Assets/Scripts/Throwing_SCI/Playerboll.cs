using System.Collections;
using UnityEngine;

public class Playerboll : MonoBehaviour
{

    float cooldown = 0;

    [SerializeField]
    GameObject Ball;

    public static bool freezeplayer; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseScript.isPaused) { 
        cooldown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && cooldown < 0)
        {


            Instantiate(Ball, transform.position + new Vector3(0, 1, 0.5f), Quaternion.identity);
            freezeplayer = true; 
            cooldown = 5;

        }


    }
    }
}
