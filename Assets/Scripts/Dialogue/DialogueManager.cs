using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueArea;
    [SerializeField] private Transform answerArea;
    [SerializeField] private GameObject AnswerObject; // Gameobject to represent an answer
    [SerializeField] private Color activeAnswerColor;

    private string action = null; // for user interaction

    // Dialogue section
    private int section;

    // Answer
    private List<GameObject> activeAnswerObjects = new List<GameObject>(); // Active answer objects on the scene
    private int selectedAnswer; // Selected answer index
    private int maxAnswerIndex;

    #region Dialogue handling
    public void StartDialogue(DialogueTree dialogueTree)
    {
        StartCoroutine(RunDialogue(dialogueTree, 0));
    }

    private IEnumerator RunDialogue(DialogueTree dialogueTree, int sectionIndex)
    {   
        #region Cycle dialogue for section
        for (int dialogue = 0; dialogue < dialogueTree.sections[section].dialogue.Length; dialogue++)
        {
            dialogueArea.text = dialogueTree.sections[section].dialogue[dialogue];

            while (action != "continue") { yield return null; }
            action = null;
        }
        #endregion

        #region Assign section based on input
        dialogueArea.text = "";
        if (!dialogueTree.sections[section].isEndOfDialogue)
        {
            StartCoroutine(HandleQuetion(dialogueTree.sections[section].answers));
            while (action == "listening") { yield return null; }

            section = dialogueTree.sections[section].answers[selectedAnswer].leadsTo;

            StartCoroutine(RunDialogue(dialogueTree, section));
        }
        #endregion
    }
    #endregion

    #region Quetion handling
    private IEnumerator HandleQuetion(Answer[] answers)
    {
        action = "listening";

        selectedAnswer = 0;    
        maxAnswerIndex = answers.Length - 1;

        RenderAnswers(answers);

        while (action == "listening") { yield return null; }  

        ClearAnswerArea();

        action = null; 
    }

    private void RenderAnswers(Answer[] answers)
    {
        dialogueArea.text = "";
        for (int answer = 0; answer < answers.Length; answer++)
        {
            GameObject answerObject = Instantiate(AnswerObject, answerArea.transform);
            activeAnswerObjects.Add(answerObject);

            answerObject.GetComponent<TextMeshProUGUI>().text = answers[answer].label;
        }
    }
    
    private void ClearAnswerArea()
    {
        foreach (GameObject answerObject in activeAnswerObjects)
        {
            Destroy(answerObject);
        }
        activeAnswerObjects.Clear();
    }
    #endregion

    #region UI input handling
    void OnProgressDialogue() { action = "continue"; } // for proceeding dialogue and selecting answers
    void OnNavigateOption(InputValue value) 
    { 
        selectedAnswer += (int)value.Get<float>(); 

        if (selectedAnswer > maxAnswerIndex) { selectedAnswer = 0; }
        if (selectedAnswer < 0) { selectedAnswer = maxAnswerIndex; }    
    }
    #endregion
}
