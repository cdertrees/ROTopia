using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MediaPortal : MonoBehaviour
{
    [SerializeField] private String _scene;
    public PlayerInfo playerInfo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Open()
    {
        // GameManager.playerPos = playerPos;
        playerInfo.SetPlayerPos(playerInfo.transform.position);
        // print("THISD BEFORE I MOVE: "+playerPos);
        SceneManager.LoadScene(_scene);
  
    }
    
}
