using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Image _characterPortrait;
    

    private bool doneTyping = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    public void DisplayDialogue( String dialogue, Sprite characterPortrait, float typingWaitTime)
    {
        doneTyping = false;
        //animate me 
        StartCoroutine(TypeCoolAndGood(dialogue, typingWaitTime));
        //show me the guy
        _characterPortrait.sprite = characterPortrait;
        
    }

    public void Clicked()
    {
        //if text is finished typing
        if (doneTyping)
        {
            //hide me
            gameObject.SetActive(false);
        }
        else
        {
            //show the whole line
            doneTyping = true;
        }
    }
    
    //animate typin one letter at a time
    IEnumerator TypeCoolAndGood(string fullLine, float waitTime)
    {
        //what is actually displayed on screen
        string currentLine = "";
        
        //for each letter in the string its trying to display
        for (int i = 0; i <= fullLine.Length; i++)
        {
            //if you skipped the text i.e. done typing is true & you're not actually done typing
            if (doneTyping)
            {
                //show text and break out
                dialogueText.text = fullLine;
                yield break;
            }
           
            //increase text that is being shown by one more letter
            currentLine = fullLine.Substring(0, i);
            //show on screen
            dialogueText.text = currentLine;
            
            //if line finished typing get out of the loop
            if (currentLine.Equals(fullLine))
            {
                doneTyping = true;
                yield break;
            }
            
            //wait before typing the next letter so its not instant
            yield return new WaitForSeconds(waitTime);
        
        }
    }
    
    
}
