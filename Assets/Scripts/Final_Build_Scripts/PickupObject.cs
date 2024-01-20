using UnityEngine;

public class PickupObject : MonoBehaviour
{

    //Darren

    public static bool KeyPickedUp = false;
    public GameObject KeyUI;

    private void Start()
    {
        KeyUI = GameObject.Find("KeyUI");
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.SetActive(false);
                KeyPickedUp = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            KeyUI.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            KeyUI.SetActive(false);
        }
    }


}