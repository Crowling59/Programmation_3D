using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private TextMeshProUGUI personnageTextComponent;
    [SerializeField] private TextMeshProUGUI dialogueTextComponent;
    
    
    //public Text nameText;
    //public Text dialogueText;

    public Animator animator;
    
    private Queue<string> sentencesQueue;

    private float index = 0;
    // Start is called before the first frame update
    void Start()
    {

        sentencesQueue = new Queue<string>();
    }

    public void StartDialogue()
    {

        index = 0;
        animator.SetBool("isOpen", true);
        
        //nameText.text = dialogue.name;

        personnageTextComponent.text = dialogue.NameNPC1;
        
        
        
        sentencesQueue.Clear();

        foreach (string sentence in dialogue.DialogueLines)
        {
            sentencesQueue.Enqueue(sentence);
        }
        Debug.Log("DisplayNextSentence");
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if (sentencesQueue.Count == 0)
        {
            Debug.Log("queue empty");
            EndDialogue();
            return;
        }
        Debug.Log("queue not empty");

        string sentence = sentencesQueue.Dequeue();
        Debug.Log(sentence);
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
        if (index % 2 == 0)
        {
            personnageTextComponent.text = dialogue.NameNPC1;
        }
        else
        {
            personnageTextComponent.text = dialogue.NameNPC2;
        }
        
        index++;

    }

    IEnumerator TypeSentence(string sentenceValue)
    {
        dialogueTextComponent.text = "";
        foreach (char letter in sentenceValue.ToCharArray())
        {
            //dialogueText.text += letter;
            dialogueTextComponent.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
