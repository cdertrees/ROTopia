using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bridge : MonoBehaviour
{
    public String nextScene;
    //the position the player should start at in the next scene
    public Vector3 sceneStartPos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Bridge Collider has collided with " + other.gameObject.name +"object");
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
            PlayerInfo.comingFromMediaPortal = false;
            GameManager.scenePlayerPos = sceneStartPos;
        }
        
    }
}
