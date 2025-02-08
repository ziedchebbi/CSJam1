using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueArea;
    [SerializeField] private TextMeshProUGUI answerArea;
    [SerializeField] private GameObject AnswerObject; // Gameobject to represent an answer

    private string action = null;

    private List<GameObject> activeAnswerObjects = new List<GameObject>(); // Active answer objects on the scene
    private int selectedAnswer; // Selected answer index

    #region TEST
    public DialogueTree testdiag; //T
    private void Start()
    {
        StartDialogue(testdiag); //T
    }
    #endregion

    #region Dialogue handling
    public void StartDialogue(DialogueTree dialogueTree)
    {
        StartCoroutine(RunDialogue(dialogueTree));
    }

    private IEnumerator RunDialogue(DialogueTree dialogueTree)
    {
        int section = 0;
        
        for (int dialogue = 0; dialogue < dialogueTree.sections[section].dialogue.Length; dialogue++)
        {
            dialogueArea.text = dialogueTree.sections[section].dialogue[dialogue];

            while (action == null) { yield return null; }
            action = null;
        }

        section = handleQuetion(dialogueTree.sections[section].answers);
    }
    #endregion

    #region Quetion handling
    private int handleQuetion(Answer[] answers)
    {
        dialogueArea.text = "";
        selectedAnswer = 0;

        // render answers
        for (int answer = 0; answer < answers.Length; answer++)
        {
            GameObject answerObject = Instantiate(AnswerObject, answerArea.transform);
            activeAnswerObjects.Add(answerObject);

            answerObject.GetComponent<TextMeshProUGUI>().text = answers[answer].label;
        }
        
        return 1;
    }
    #endregion

    #region UI input handling
    void OnProgressDialogue() { action = "continue"; }
    #endregion
}
