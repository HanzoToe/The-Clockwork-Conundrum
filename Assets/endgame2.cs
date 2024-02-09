using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public string[] dialogueLines;
    public float delayBetweenCharacters = 0.1f;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public PlayerMovement playerMovement;
    public GameObject player;
    public static bool Freezeplayer;
    FadeInOut fadeinout;

    private bool triggered = false;

    private void Start()
    {
        fadeinout = GetComponent<FadeInOut>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !triggered)
        {
            Freezeplayer = true;
            StartCoroutine(ShowDialogue());
            triggered = true;
        }
    }

    private IEnumerator ShowDialogue()
    {
        dialogueBox.SetActive(true);
        foreach (string line in dialogueLines)
        {
            yield return TypeSentence(line);
            yield return new WaitForSeconds(1f); // Wait for a moment between lines
        }
        fadeinout.FadeIn();
        yield return new WaitForSeconds(1f); // Wait for a moment after all dialogue
        LoadCredits();
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(delayBetweenCharacters);
        }
    }

    void LoadCredits()
    {
        SceneManager.LoadScene("Cedits"); 
    }
}
