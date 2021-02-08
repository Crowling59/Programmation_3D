
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName="Dialogue")]

public class Dialogue : ScriptableObject
{
    
    [SerializeField] private string nameNPC1;
    [SerializeField] private string nameNPC2;
    [TextArea(4,10)]
    [SerializeField] private List<string> dialogueLines;
    
    public List<string> DialogueLines => dialogueLines;
    public string NameNPC1 => nameNPC1;
    public string NameNPC2 => nameNPC2;
}
