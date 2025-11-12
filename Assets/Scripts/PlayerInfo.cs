using System;
using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public static bool comingFromMediaPortal;
     
    public static Vector3 playerPos;
    public static char playerDirection;
    
    // public TextMeshPro text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    public void SetPlayerPos(Vector3 pos, bool fromMediaPortal)
    {
        comingFromMediaPortal = fromMediaPortal;
        playerPos = pos;
        playerDirection = GameManager.GM.lastMovementDir;
    }

    public void GoBack(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
}
