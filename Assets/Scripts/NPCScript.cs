using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public Sprite portrait;
    public float typingWaitTime;
    //Responses to each emote, same order the emote names as assigned in the inspector 
    public List<String> responses;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip npcVoice;
    [SerializeField] [Range(-2, 2)] private float pitchMin, pitchMax;
    
    void Start()
    {
        
    }

    public void Respond(String emote)
    {
        int tempIndex = 0;
        
        GameManager.GM.ShowDialogueBox(true);
        switch (emote)
        {
            case "Emote0":
                tempIndex = 0;
                break;
            case "Emote1":
                //dialogue display for this emote
                tempIndex = 1;
                break;
            case "Emote2":
                //dialogue display for this emote
                tempIndex = 2;
                break;
        }
        
        GameManager.GM.dialogueScript.DisplayDialogue(responses[tempIndex], portrait, typingWaitTime, npcVoice, pitchMin, pitchMax);
        
    }
}
