using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Train_Inside : MonoBehaviour
{
    //Hi

    FadeInOut fade;
    public GameObject pressEUI;
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

        fade.Fade_in = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Train_Scene_1");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerisatthedoor = true;
            pressEUI.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        playerisatthedoor = false;
        pressEUI.SetActive(false);
    }





}
