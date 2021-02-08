using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //public Dialogue2 dialogue;
    [SerializeField] private DialogueManager manager;

    public void TriggerDialogue()
    {
        manager.StartDialogue();
    }
}
