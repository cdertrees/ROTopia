using System;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           print("player u ");
        }
    }
}
