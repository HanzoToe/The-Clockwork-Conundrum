using UnityEngine;

public class PickupObject : MonoBehaviour
{

    //Darren

    public static bool KeyPickedUp = false;
    public GameObject KeyUI; 

    private void Start()
    {
        FindUIElement();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        FindUIElement();
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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            if (KeyUI != null)
            {
                KeyUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            if(KeyUI != null)
            {
                KeyUI.SetActive(false);
            }
        }
    }


    private void FindUIElement()
    {
        // Find the Canvas GameObject in the currently active scene
        Canvas canvas = FindObjectOfType<Canvas>();

        if (canvas != null)
        {
            // Assuming your UI GameObject is a direct child of the Canvas
            Transform uiElementTransform = canvas.transform.Find("KeyUI");

            if (uiElementTransform != null)
            {
                KeyUI = uiElementTransform.gameObject;
                Debug.Log("UI Element found!");
                // You can activate it here if needed
                // PressQUI.SetActive(true);
            }
            else
            {
                Debug.LogError("UI Element not found. Check the name or tag.");
            }
        }
        else
        {
            Debug.LogError("Canvas not found.");
        }
    }


}