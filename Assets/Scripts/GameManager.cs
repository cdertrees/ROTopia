using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager GM { get; private set; }

    //GM Variables - Sources of truth for the whole game.
    
    //decides player is actively exploring the map
    public bool canMove = true;
    
    //STORE PLAYER POS IN HERE WHEN WE GO TO THE MEDIA PORTAL!
    public Vector2 playerPos;
    
    //Scripts
    public MovementScript movementScript;
    public EmoteScript emoteScript;
    public DialogueBox dialogueScript;

    private void Awake()
    {
        //If you are not me kill yourself!!!!!
        if (GM != null && GM != this)
        {
            Destroy(this);
        }
        else
        {
            //i am the gamemanager this is me i am now a singleton waow
            GM = this;
        }
        
        ShowDialogueBox(false);

    }

    //disable player movement. this will happen whenever the player is interacting with an npc or is typing in the chat box
    public void SetCanMove(bool val)
    {
        canMove = val;
    }

    public void ShowDialogueBox(bool setActive)
    {
        dialogueScript.gameObject.SetActive(setActive);
    }
    
}
