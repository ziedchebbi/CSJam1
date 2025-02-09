using UnityEngine;

public class Tester : MonoBehaviour
{
    public DialogueTree dialogue;

    void Start()
    {
        GetComponent<DialogueManager>().StartDialogue(dialogue);
    }
}
