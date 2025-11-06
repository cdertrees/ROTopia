using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Image _characterPortrait;

    public AudioSource AS;
    
    private bool _doneTyping = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void DisplayDialogue( String dialogue, Sprite characterPortrait, float typingWaitTime, AudioClip npcVoice, float pitchMin, float pitchMax)
    {
        _doneTyping = false;
        //animate me 
        StartCoroutine(TypeCoolAndGood(dialogue, typingWaitTime, npcVoice, pitchMin, pitchMax));
        //show me the guy
        _characterPortrait.sprite = characterPortrait;
        
    }

    public void Clicked()
    {
        //if text is finished typing
        if (_doneTyping)
        {
            //hide me
            gameObject.SetActive(false);
        }
        else
        {
            //show the whole line
            _doneTyping = true;
        }
    }
    
    //animate typin one letter at a time
    IEnumerator TypeCoolAndGood(string fullLine, float waitTime, AudioClip npcVoice, float pitchMin, float pitchMax)
    {
        //what is actually displayed on screen
        string currentLine = "";
        
        //for each letter in the string its trying to display
        for (int i = 0; i <= fullLine.Length; i++)
        {
            //if you skipped the text i.e. done typing is true & you're not actually done typing
            if (_doneTyping)
            {
                //show text and break out
                dialogueText.text = fullLine;
                yield break;
            }
           
            //increase text that is being shown by one more letter
            currentLine = fullLine.Substring(0, i);
            
            //stop previous voice clip so they dont overlap
            AS.Stop();
            //play the npc voice clip at a random pitch in the npcs voice range
            AS.pitch = Random.Range(pitchMin, pitchMax);
            AS.PlayOneShot(npcVoice);
            
            //show on screen
            dialogueText.text = currentLine;
            
            //if line finished typing get out of the loop
            if (currentLine.Equals(fullLine))
            {
                _doneTyping = true;
                yield break;
            }
            
            //wait before typing the next letter so its not instant
            yield return new WaitForSeconds(waitTime);
        
        }
    }
    
    
}
