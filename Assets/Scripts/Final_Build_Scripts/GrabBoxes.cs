using UnityEngine;

public class BoxInteraction : MonoBehaviour
{

    //Darren
    private bool canPull = false;
    private GameObject boxToPull;
    public bool BoxInHand = false;
    public static bool OnBox = false; 

    // Update is called once per frame
    void Update()
    {
        //Allows the box to be pulled
        if (canPull && Input.GetKey(KeyCode.Q) && !BoxInHand)
        {
            CarryBox();
            BoxInHand = true; 
        }
        else if (!canPull && boxToPull != null && Input.GetKeyUp(KeyCode.Q) && BoxInHand)
        {
            DropBox();
            BoxInHand = false;
        }

        if (!BoxInHand)
        {
            Debug.Log("NO BOX");
        }

        if (OnBox)
        {
            Debug.Log("OnBox");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Boxes") && !BoxInHand)
        {
            canPull = true;
            boxToPull = collision.gameObject;
            Debug.Log("Can pull");
        }
        if (collision.collider.CompareTag("Boxes"))
        {
            OnBox = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Boxes"))
        {
            OnBox = false; 
            canPull = false;
            Debug.Log("Can't pull");
        }
    }

    private void CarryBox()
    {
        if (boxToPull != null)
        {
            // Attach the box to the player
            boxToPull.transform.parent = transform;

            // A        djust the position and rotation for a better look
            boxToPull.transform.localPosition = new Vector3(-1f, 0.5f, 0f);
            boxToPull.transform.localRotation = Quaternion.identity;

            // Disable box's rigidbody while carrying to avoid physics issues
            Rigidbody2D boxRigidbody = boxToPull.GetComponent<Rigidbody2D>();
            if (boxRigidbody != null)
            {
                boxRigidbody.simulated = false;
            }
        }
    }

    private void DropBox()
    {
        if (boxToPull != null)
        {
            // Reset the parent to detach the box from the player
            boxToPull.transform.parent = null;

            // Enable box's rigidbody after dropping
            Rigidbody2D boxRigidbody = boxToPull.GetComponent<Rigidbody2D>();
            if (boxRigidbody != null)
            {
                boxRigidbody.simulated = true;
            }
        }
    }
}
