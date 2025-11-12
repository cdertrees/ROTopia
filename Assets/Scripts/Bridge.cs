using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bridge : MonoBehaviour
{
    public String nextScene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Bridge Collider has collided with " + other.gameObject.name +"object");
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
