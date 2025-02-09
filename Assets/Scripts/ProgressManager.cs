using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{   
    public GameObject dialogueBackground;

    private DialogueManager dialogueManager;
    private PlayerMovement playerMovement;

    private int phase = 1;

    [SerializeField] private List<DialogueTree> dialogs = new List<DialogueTree>();

    public GameObject klaus;
    public Transform klausPos;

    public GameObject General;
    public Transform GeneralPos;

    private void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        dialogueManager.enabled = false;
        playerMovement.enabled = true;
        dialogueBackground.SetActive(false);

        ChangeMode();
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
            Destroy(klaus);
            Instantiate(General, GeneralPos);
            ChangeMode();
            dialogueManager.StartDialogue(dialogs[1]);
        }
    }
}
