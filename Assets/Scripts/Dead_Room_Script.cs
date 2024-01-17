using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead_Room_Script : MonoBehaviour
{
    //Hi

    FadeInOut fade;
    public GameObject pressEUI;
    public GameObject player;
    public GameObject door;
    public float timebeforenextscene;
    public bool playerisatthedoor;
    public GameObject missingkey;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerisatthedoor == true && PickupObject.KeyPickedUp)
        {
            StartCoroutine(_door());
        }
    }

    public IEnumerator _door()
    {

        yield return new WaitForSeconds(timebeforenextscene);

        fade.Fade_in = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Dead_Body");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && PickupObject.KeyPickedUp)
        {
            playerisatthedoor = true;
            pressEUI.SetActive(true);
        }
        else if(collision.gameObject.tag == "Player" && !PickupObject.KeyPickedUp)
        {
            missingkey.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        playerisatthedoor = false;
        pressEUI.SetActive(false);
        missingkey.SetActive(false);
    }





}
