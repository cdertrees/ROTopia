using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class Chatbox : MonoBehaviour
{
    //Scrollbar component on vertical scrollbar obj to reset chat box to the bottom
    private Scrollbar _scroll;
    private TextMeshProUGUI _chatContent;
    private TMP_InputField _chatInput;
    
    //emotes so we can change names later
    public String[] emotes = new String[3];

    //0 clue if this is how i am supposed to do this I hate you unity input system
    // public InputActionReference input;
    
    void Start()
    {
        //find those babies
        _scroll = GetComponentInChildren<Scrollbar>();
        _chatContent = GetComponentInChildren<TextMeshProUGUI>();
        _chatInput = GetComponentInChildren<TMP_InputField>();
        
        //reset everything
        _chatContent.text = "Welcome to Rotopia!\nThis is a test line!\n";
        ResetScrollBar();
    }

    public void Update()
    {
        //will replace w unity input system. unsure if i need to wait for hope's stuff to come in first
        //if i press enter, have the text field selected, and it is not empty
        if (Input.GetKeyDown(KeyCode.Return) &&
            EventSystem.current.currentSelectedGameObject.name==_chatInput.gameObject.name &&
            _chatInput.text != "")
        {
           //grab chat input submission
            var textInput = _chatInput.text;
            var validEmote = false;
            
            //go through list of emotes, if any are valid then we are good to go!
            foreach (var str in emotes)
            {
                //if the current emote is valid stop looking
                if (textInput == "/"+str)
                {
                    validEmote = true;
                    break;
                }
                
            }
            
            //if emote is valid start emoting 
            if (validEmote)
            {
                //get rid of the \
                PushChatMessage("This guy hitting the "+ textInput.Substring(1, textInput.Length-1) +"!!!!!!");
                //play emote from player's animator which doesnt exist yet
            }
            //if not inform the player
            else
            {
                PushChatMessage("Invalid Emote : (");
            }
            
            
        }
        
    }

    public void ResetScrollBar()
    {
        //reset scroll bar to bottom
        _scroll.value = 0;
    }
    
    public void PushChatMessage(String messageContent)
    {
        _chatInput.text = "";
        //adds a new line and the desired message in the chat content text box
        //sizing is handled by the content size fitter component in inspector
        _chatContent.text += messageContent + "\n";
        //sound effect here probably eventually
        //then scrollbar resets so you can see the bottom msg :)
        ResetScrollBar();
    }
    
}

