using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    private Image _characterPortrait;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueText = GetComponentInChildren<TextMeshProUGUI>();
        _characterPortrait = GetComponentInChildren<Image>();
       
    }

    public void DisplayDialogue( String dialogue)
    {
        //animate me later
        dialogueText.text = dialogue;
        //_characterPortrait.sprite = characterPortrait;
    }
    
}
