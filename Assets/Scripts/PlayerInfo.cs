using System;
using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public static Vector2 playerPos = new Vector2(0f,-2.75f);
    public static char playerDirection;
    
    // public TextMeshPro text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    public void SetPlayerPos(Vector2 pos)
    {
        playerPos = pos;
    }
    
    public Vector2 GetPlayerPos()
    {
        return playerPos;
    }

    public void GoBack(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
}
