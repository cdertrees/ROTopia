using System;
using System.Collections;
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

   public bool gridBased;
   private Vector2 _startMove;
   private Vector2 _endMove;
   private int _frameCount;
   private bool _gridMoveStart;

   private void Awake()
   {
      //This is to keep it all private lol lmao even
      _playerRigidbody = GetComponent<Rigidbody2D>();

      //This can be changed to whatever value to make the character faster
      _speed = 3;
   }

   private void FixedUpdate()
   {
      if (gridBased)
      {
         _frameCount++;
         
         if (GameManager.GM.canMove)
         {
            if (_movementInput != Vector2.zero)
            {
               //if (_frameCount % 6 == 0)
               if (!_gridMoveStart)
               {
                  _startMove = transform.position;
                  _endMove = new Vector2(_startMove.x+_movementInput.x,_startMove.y+(_movementInput.y/2));
                  StartCoroutine(SmoothGridMove());
                  //transform.position = _endMove;
               }
            }
         }
      }
      else
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
   }
   
   void OnMovement(InputValue inputValue)
   {
      //now the input system is all together in 2D movement
      _movementInput = inputValue.Get<Vector2>();
   }

   IEnumerator SmoothGridMove()
   {
      _gridMoveStart = true;
      float moveTimer = 0;

      while (moveTimer < .25f)
      {
         Debug.Log("hi");
         _smoothMovement = Vector2.SmoothDamp
            (_smoothMovement, _endMove, ref _smoothMovementVelocity, 0.25f);
         transform.position = new Vector3(_smoothMovement.x, _smoothMovement.y, _smoothMovement.y);
         moveTimer += Time.deltaTime;
      }

      _gridMoveStart = false;
      yield return new WaitForSeconds(.01f);
   }
}
