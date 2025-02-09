using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{   
    public GameObject blackScreen;
    public TextMeshProUGUI blackScreenText;

    public GameObject dialogueBackground;

    private DialogueManager dialogueManager;
    private PlayerMovement playerMovement;

    private int phase = 1;

    [SerializeField] private List<DialogueTree> dialogs = new List<DialogueTree>();

    public GameObject klaus;
    public GameObject General;
    public GameObject Hanz;

    private void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        dialogueManager.enabled = false;
        playerMovement.enabled = true;
        dialogueBackground.SetActive(false);

        ChangeMode();
        StartCoroutine(BlackScreen("Episode 1: The news"));
        dialogueManager.StartDialogue(dialogs[0]);
    }

    public void ChangeMode()
    {
        dialogueBackground.SetActive(!dialogueBackground.activeSelf);
        dialogueManager.enabled = !dialogueManager.enabled;
        playerMovement.enabled = !playerMovement.enabled;
    }

    public void Proceed()
    {
        phase++;

        if (phase == 2)
        {
            StartCoroutine(BlackScreen("Episode 2: The Manhattan project"));
            klaus.SetActive(false);
            General.SetActive(true);
            ChangeMode();
            dialogueManager.StartDialogue(dialogs[1]);
        }

        if (phase == 3)
        {
            StartCoroutine(BlackScreen("Episode 3 Part 1: Bad news"));
            klaus.SetActive(true);
            General.SetActive(false);
            Hanz.SetActive(true);
            ChangeMode();
            dialogueManager.StartDialogue(dialogs[2]);
        }

        if (phase == 4)
        {
            EndThisShit("To Be Continued...");
        }
    }

    private IEnumerator BlackScreen(string text)
    {
        blackScreenText.text = text;
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        blackScreenText.text = "";
        blackScreen.SetActive(false);
    }

    public void EndThisShit(string text)
    {
        blackScreenText.text = text;
        blackScreen.SetActive(true);
    }
}
