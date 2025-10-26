using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chatbox : MonoBehaviour
{
    //Scrollbar component on vertical scrollbar obj to reset chat box to the bottom
    private Scrollbar _scroll;
    private TextMeshProUGUI _chatContent;
    void Start()
    {
        //find those babies
        _scroll = GetComponentInChildren<Scrollbar>();
        _chatContent = GetComponentInChildren<TextMeshProUGUI>();
        
        //reset everything
        _chatContent.text = "Welcome to Rotopia!\nThis is a test line!";
        ResetScrollBar();
        PushChatMessage("Test Push");
    }

    public void ResetScrollBar()
    {
        //reset scroll bar to bottom
        _scroll.value = 0;
    }
    
    public void PushChatMessage(String messageContent)
    {
        //adds a new line and the desired message in the chat content text box
        //sizing is handled by the content size fitter component in inspector
        _chatContent.text += "\n" + messageContent;
        //sound effect here probably eventually
        //then scrollbar resets so you can see the bottom msg :)
        ResetScrollBar();
    }
    
}
