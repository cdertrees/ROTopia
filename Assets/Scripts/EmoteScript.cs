using System;
using System.Collections.Generic;
using UnityEngine;

public class EmoteScript : MonoBehaviour
{
    private Animator _emoteAnim;

    //NPCS in range of the player
    public List<NPCScript> NPCS;
    public List<MediaPortal> MediaPortals;
    
    // private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // player = GetComponentInParent<MovementScript>().gameObject;
        _emoteAnim = GetComponent<Animator>();
    }

    //When the player enters an emote that exists into the chatbox, this function is called
    /// <summary>
    /// A function that plays an animation on the player given a specified direction. Can be a dance or a walk animation.
    /// </summary>
    /// <param name="animName">the EXACT NAME!!!! of the animation as a string minus it's direction. double check in editor.</param>
    /// <param name="direction">a character representing the direction of an emote (ONLY U,D,R,L). added to the end of the emote's name to find the correct directional variant.</param>
    public void Emote(String animName, char direction)
    {
        var fullname = animName + direction;
        _emoteAnim.Play(fullname);
        
        // last npc added to radius (hopefully the closest one) will be called to respond to the player. 

        if (animName != "Walk")
        {
            if (MediaPortals.Count > 0 )
            {
                
                MediaPortals[^1].Open();
            }
            else if (NPCS.Count > 0)
            {
                NPCS[^1].Respond(animName);
            } 
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If an npc enters the emote radius, add them to the npc list
        if (other.gameObject.CompareTag("NPC"))
        {
            NPCS.Add(other.GetComponent<NPCScript>());
        }
        else if (other.gameObject.CompareTag("MediaPortal"))
        {
            MediaPortals.Add(other.GetComponent<MediaPortal>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //remove npc if they exit the radius
        if (other.gameObject.CompareTag("NPC"))
        {
            NPCS.Remove(other.GetComponent<NPCScript>());
        }
        if (other.gameObject.CompareTag("MediaPortal"))
        {
            MediaPortals.Remove(other.GetComponent<MediaPortal>());
        }
    }
}
