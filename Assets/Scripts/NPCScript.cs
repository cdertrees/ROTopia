using System;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Respond(String emote)
    {
        switch (emote)
        {
            case "Emote0":
                //dialogue display for this emote
                
                Debug.Log("Dude wow");
                break;
            case "Emote1":
                //dialogue display for this emote
                
                Debug.Log("wtf!!!!");
                break;
            case "Emote2":
                //dialogue display for this emote
                
                Debug.Log("What are you doing on valentines day?");
                break;
        }
    }
}
