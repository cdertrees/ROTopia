using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
   //Booleans to determine if the player is holding a direction to move
   private bool _controlLeft;
   private bool _controlRight;
   private bool _controlUp;
   private bool _controlDown;
   private int _frameCount = 0;
   private void FixedUpdate()
   {
      //To count how many frames have gone since the game has started
      _frameCount++;
      
      //The original 
      //Used to slow down movement by making it check every few frames instead of every frame
      if (_frameCount % 3 == 0)
      {
         //If the player is holding down a direction, move the character in that direction
         
         //This is a direct tile movement where it places the player on the next tile
         //This is the base movement, and will be updated with better stuff over time
         //This may end up just getting commented out instead of deleted in case it's needed
         if (_controlLeft)
         {
            transform.position += new Vector3(-.5f,.25f,0f);
         }
         if (_controlRight)
         {
            transform.position += new Vector3(.5f,-.25f,0f);
         }
         if (_controlUp)
         {
            transform.position += new Vector3(.5f,.25f,0f);
         }
         if (_controlDown)
         {
            transform.position += new Vector3(-.5f,-.25f,0f);
         }
      }
   }
   //The functions that say when the player is holding a direction to move
   //These 4 are copy and paste of each other, so descriptions on this one only
   void OnMoveLeft(InputValue value)
   {
      //The Input Value says 1 when the button is held down and 0 when released
      //This checks if the value is greater than 0 (aka it's 1)
      //Then it sets the boolean to true or false depending on that
      
      //To check if I fucked up
      Debug.Log(value.Get<float>());
      if (value.Get<float>() > 0)
      {
         _controlLeft = true;
      }
      else
      {
         _controlLeft = false;
      }
   }
   void OnMoveRight(InputValue value)
   {
      Debug.Log(value.Get<float>());
      if (value.Get<float>() > 0)
      {
         _controlRight = true;
      }
      else
      {
         _controlRight = false;
      }
   }
   void OnMoveUp(InputValue value)
   {
      Debug.Log(value.Get<float>());
      if (value.Get<float>() > 0)
      {
         _controlUp = true;
      }
      else
      {
         _controlUp = false;
      }
   }
   void OnMoveDown(InputValue value)
   {
      Debug.Log(value.Get<float>());
      if (value.Get<float>() > 0)
      {
         _controlDown = true;
      }
      else
      {
         _controlDown = false;
      }
   }
}
