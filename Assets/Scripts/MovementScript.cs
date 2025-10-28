using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
   private Vector2 _movementInput;
   private Rigidbody2D _playerRigidbody;
   private float _speed;
   private Vector2 _smoothMovement;
   private Vector2 _smoothMovementVelocity;

   private void Awake()
   {
      //This is to keep it all private lol lmao even
      _playerRigidbody = GetComponent<Rigidbody2D>();

      //This can be changed to whatever value to make the character faster
      _speed = 3;
   }

   private void FixedUpdate()
   {
      //This only happens if you're allowed to move
      if (GameManager.GM.canMove)
      {
         //The smooth movement stuff
         //SmoothDamp used over Lerp because Lerp looks like ice physics
         //The smooth time determines how much the player slides
         _smoothMovement = Vector2.SmoothDamp
            (_smoothMovement, _movementInput, ref _smoothMovementVelocity, 0.05f);
      
         //Where the movement is actually set
         //This is also why the speed is a variable...to be able to change the speed
         _playerRigidbody.linearVelocity = _smoothMovement * _speed;
      }
      //This is here to stop a bug
      //Player would keep moving if button was held when clicking on chat box
      else
      {
         _playerRigidbody.linearVelocity = Vector2.zero;
      }
   }
   
   void OnMovement(InputValue inputValue)
   {
      //now the input system is all together in 2D movement
      _movementInput = inputValue.Get<Vector2>();
   }
}
