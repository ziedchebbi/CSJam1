using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    [SerializeField] private DialogueTree dialogueTree;
    public void StartDialogue()
    {
        GameObject.Find("GM").GetComponent<ProgressManager>().ChangeMode();
        GameObject.Find("GM").GetComponent<DialogueManager>().StartDialogue(dialogueTree);
    }
}
