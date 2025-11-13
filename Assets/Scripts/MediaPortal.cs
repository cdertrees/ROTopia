using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MediaPortal : MonoBehaviour
{
    [SerializeField] private String _scene;
    public PlayerInfo playerInfo;
    public GameObject selectedIcon;
    

    public void Open()
    {
        playerInfo.SetPlayerPos(playerInfo.transform.position, true);
        SceneManager.LoadScene(_scene);
  
    }
    
}
