using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM { get; private set; }
    
    //Player Emote
    public EmoteScript _emoteScript;
    
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
