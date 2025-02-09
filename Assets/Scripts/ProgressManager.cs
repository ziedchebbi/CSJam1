using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{   
    public GameObject dialogueBackground;

    private DialogueManager dialogueManager;
    private PlayerMovement playerMovement;

    [SerializeField] private List<DialogueTree> dialogs = new List<DialogueTree>();

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
}
