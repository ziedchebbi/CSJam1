using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<DialogueStarter>().StartDialogue();
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
