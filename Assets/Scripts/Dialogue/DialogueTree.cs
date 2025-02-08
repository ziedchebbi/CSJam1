using UnityEngine;

[CreateAssetMenu(fileName = "DialogueTree", menuName = "Dialogue Tree")]
public class DialogueTree : ScriptableObject
{
    public DialogueSection[] sections;
}

[System.Serializable]
public struct DialogueSection 
{
    [TextArea]
    public string[] dialogue;
    public Answer[] answers;
}

[System.Serializable]
public struct Answer
{
    public string label;
    public int leadsTo;
}
