using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFunction : MonoBehaviour
{
    FadeInOut fade;

    public GameObject player;
    public GameObject door;
    public float timebeforenextscene;
    public bool playerisatthedoor;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerisatthedoor == true)
        {
            StartCoroutine(_door());
        }
    }

    public IEnumerator _door()
    {
        yield return new WaitForSeconds(timebeforenextscene);
        player.SetActive(false);
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Scene 2");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playerisatthedoor = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        playerisatthedoor = false;
    }





}
