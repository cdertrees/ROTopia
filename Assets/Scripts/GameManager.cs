using System;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    //GM Variables - Sources of truth for the whole game.
    public static GameManager GM;
    
    //decides player is actively exploring the map
    public bool canMove = true;
    public  char lastMovementDir;
    
    //STORE PLAYER POS IN HERE WHEN WE GO TO THE MEDIA PORTAL!
    // public static Vector2 playerPos;
    
    //Scripts
    public MovementScript movementScript;
    public EmoteScript emoteScript;
    public DialogueBox dialogueScript;
    public PlayerInfo playerInfoScript;
    
    //The player position that the player should start at UNLESS coming from a media portal
    public Vector3 scenePlayerPos;
    public Vector3 fromPortalPlayerPos;
    
    public bool mediaPortalScene;
    
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
        
        //DontDestroyOnLoad(this.gameObject);
        if (!PlayerInfo.comingFromMediaPortal)
        {
            print("should be at this position:"+scenePlayerPos);
            playerInfoScript.SetPlayerPos(scenePlayerPos, false);
            print("trying to set at" + PlayerInfo.playerPos);
        }
        else
        {
            
        }
           
            
       
    }

    private void Start()
    {
        // print("THIS AFTER I MOCE pos: "+playerPos);
        if (mediaPortalScene)
        {
            ShowDialogueBox(false);
        }
        
     
        

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
    
    /// <summary>
    /// A function that plays an animation on the player given a specified direction. Can be a dance or a walk animation.
    /// </summary>
    /// <param name="animationName">the EXACT NAME!!!! of the animation as a string minus it's direction. double check in editor.</param>
    /// <param name="direction">a character representing the direction of the animation (ONLY U,D,R,L). added to the end of the anim's name to find the correct directional variant.</param>
    public void PlayerAnimate(string animationName, char direction)
    {
        lastMovementDir = direction;
        emoteScript.Emote(animationName, direction);
    }
    
    //a secondary version only to be used by the chatbox, does not require directional input
    public void PlayerAnimate(string animationName)
    {
        emoteScript.Emote(animationName, lastMovementDir);
    }
    
}
