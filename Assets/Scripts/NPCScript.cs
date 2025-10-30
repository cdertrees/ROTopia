using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public Sprite portrait;
    //Responses to each emote, same order the emote names as assigned in the inspector 
    public List<String> responses;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Respond(String emote)
    {
        GameManager.GM.ShowDialogueBox(true);
        switch (emote)
        {
            case "Emote0":
                //dialogue display for this emote
                GameManager.GM.dialogueScript.DisplayDialogue(responses[0]);
                break;
            case "Emote1":
                //dialogue display for this emote
                GameManager.GM.dialogueScript.DisplayDialogue(responses[1]);
                break;
            case "Emote2":
                //dialogue display for this emote
                GameManager.GM.dialogueScript.DisplayDialogue(responses[2]);
                break;
        }
    }
}
