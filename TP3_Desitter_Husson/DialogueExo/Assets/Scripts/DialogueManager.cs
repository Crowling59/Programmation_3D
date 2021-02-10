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

    public Animator animatorDialogueBox;
    public Animator animatorImage1;
    public Animator animatorImage2;
    public Animator animatorImage3;
    
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
        animatorDialogueBox.SetBool("isOpen", true);
        animatorImage1.SetBool("isOpen", true);
        animatorImage2.SetBool("isOpen", true);
        animatorImage3.SetBool("isOpen", true);

        personnageTextComponent.text = dialogue.NameNPC1;

        sentencesQueue.Clear();

        foreach (string sentence in dialogue.DialogueLines)
        {
            sentencesQueue.Enqueue(sentence);
        }
       
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if (sentencesQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentencesQueue.Dequeue();
        
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
        dialogueTextComponent.text = sentenceValue;
        
        for(int i = 0;i<sentenceValue.Length+1;i++)
        {
            dialogueTextComponent.maxVisibleCharacters = i;
            
            yield return null;
        }
    }

    void EndDialogue()
    {
        animatorDialogueBox.SetBool("isOpen", false);
        animatorImage1.SetBool("isOpen", false);
        animatorImage2.SetBool("isOpen", false);
        animatorImage3.SetBool("isOpen", false);
    }
}
