using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public static bool KeyPickedUp = false;

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
}