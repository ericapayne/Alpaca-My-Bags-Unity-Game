using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    //added to make it start without button press
    public void Start()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        
        
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
        //Destroys Start Button
       // Destroy(gameObject);
    }
}
