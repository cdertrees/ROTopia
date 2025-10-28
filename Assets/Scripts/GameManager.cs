using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager GM { get; private set; }

    //GM Variables - Sources of truth for the whole game.
    
    //decides player is actively exploring the map
    public bool canMove = true;
    
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
            GM = this;
        }

    }

    //disable player movement. this will happen whenever the player is interacting with an npc or is typing in the chat box
    public void SetCanMove(bool val)
    {
        canMove = val;
    }
    
    
}
