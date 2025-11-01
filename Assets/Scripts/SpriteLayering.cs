using System;
using UnityEngine;

public class SpriteLayering : MonoBehaviour
{
    public bool doesMove;
    public Vector3 currentPosition;
    void Awake()
    {
        //First just setting the current position
        currentPosition = transform.position;
        
        //The bread and butter
        //Keeps the X and Y the same, but sets the Z to be the same as the Y
        currentPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.y);

        //This now actually sets the position back into the current position
        transform.position = currentPosition;
    }

    private void Update()
    {
        if (doesMove)
        {
            currentPosition = transform.position;
            currentPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.y);
            
            transform.position = currentPosition;
        }
    }
}
