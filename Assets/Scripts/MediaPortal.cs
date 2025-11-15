using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MediaPortal : MonoBehaviour
{
    //scene i am going to
    [SerializeField] private String _scene;

    public bool takesPoobis, takesSchlibby, takesMarmadizzle;
    //script holding important info abt player
    public PlayerInfo playerInfo;
    
    //selection arrow showing the player what portal is selected
    public GameObject selectedIcon;
    

    public void Open()
    {
        playerInfo.SetPlayerPos(playerInfo.transform.position, true);
        SceneManager.LoadScene(_scene);
  
    }
    
}
