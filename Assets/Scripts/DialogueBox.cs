using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    private TextMeshProUGUI _dialogueText;
    private Image _characterPortrait;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _dialogueText = GetComponentInChildren<TextMeshProUGUI>();
        _characterPortrait = GetComponentInChildren<Image>();
        this.gameObject.SetActive(false);
    }

    public void DisplayDialogue(Sprite characterPortrait, String dialogue)
    {
        //animate me later
        _dialogueText.text = dialogue;
        _characterPortrait.sprite = characterPortrait;
    }
    
}
