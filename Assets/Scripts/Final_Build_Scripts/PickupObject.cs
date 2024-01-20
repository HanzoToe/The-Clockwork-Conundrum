using UnityEngine;

public class PickupObject : MonoBehaviour
{

    //Darren

    public static bool KeyPickedUp = false;
    public string keyUITag = "KeyTag";

    private void Start()
    {
        GameObject KeyUI = GameObject.FindWithTag("KeyTag");
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
            GameObject keyUIGameObject = GameObject.FindWithTag(keyUITag);
            if (keyUIGameObject != null)
            {
                keyUIGameObject.SetActive(true);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            GameObject keyUIGameObject = GameObject.FindWithTag(keyUITag);
            if (keyUIGameObject != null)
            {
                keyUIGameObject.SetActive(false);
            }
        }
    }


}