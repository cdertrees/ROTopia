using System;
using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
   private Vector2 _movementInput;
   private Rigidbody2D _playerRigidbody;
   [SerializeField] private float _speed;
   private Vector2 _smoothMovement;
   private Vector2 _smoothMovementVelocity;

   private bool moving;
   private Vector2 _startMove;
   private Vector2 _endMove;
   private Vector2 _heldinput;
   private int _frameCount;
   private bool _gridMoveStart, _gridMoveCollide;
   private float _moveTimer, _collideTimer;
   public Collider2D moveCollider;

   //'U', 'D', 'L', 'R'
   private char dir;
   
   private void Awake()
   {
      Application.targetFrameRate = 60;
      //This is to keep it all private lol lmao even
      _playerRigidbody = GetComponent<Rigidbody2D>();
      transform.position = PlayerInfo.playerPos;
   }

   public float marginx;
   public float marginy;
   private void FixedUpdate()
   {
      _frameCount++;
         
      if (GameManager.GM.canMove)
      {
         //The smooth movement code now
         if (_gridMoveStart && !_gridMoveCollide)
         {
            moving = true;
            
            //The thing that makes it nice and smooth
            _smoothMovement = Vector2.SmoothDamp(transform.position, _endMove, ref _smoothMovementVelocity, _speed);
            transform.position = new Vector3(_smoothMovement.x, _smoothMovement.y, _smoothMovement.y);
               
            //pulls margin from current pos and then target pos in both axis
            marginx = Mathf.Abs(transform.position.x - _endMove.x);
            marginy = Mathf.Abs(transform.position.y - _endMove.y);
            //checks if margin is allowable for snap
            if (marginx < 0.01f && marginy < 0.01f)
            {
               moving=false;
               _gridMoveStart = false;
               // Debug.Log("end position = "+transform.position);
               //This snaps it directly to the grid
               transform.position = new Vector3(_endMove.x, _endMove.y, 0);
            }
         }
         if (_movementInput != Vector2.zero)
         {
            if (!_gridMoveStart)
            {
               RaycastHit hit;
               Debug.DrawRay(new Vector2(transform.position.x,transform.position.y+1), transform.TransformDirection(_movementInput) * 1f, Color.yellow); 
               if (!Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y+1), transform.TransformDirection(_movementInput), 1f))
               {
                  //The start move is set before anything happens to get the beginning point
                  _startMove = transform.position;
                  //The end move is calculated based on what movement input is given
                  _endMove = new Vector2(_startMove.x+_movementInput.x,_startMove.y+_movementInput.y);
                  //This is to reset all the smooth movement stuff
                  _smoothMovement = _startMove;
                  //disable this for player to do some weird drift/jump thing :)
                  _smoothMovementVelocity = Vector2.zero;
                  //only play animation once when walking
                  GameManager.GM.PlayerAnimate("Walk", dir);
                  _gridMoveStart = true;
                  // Debug.Log("end move = "+_endMove);
               }
               
            }
         }
      }
         
      #region oldmovecode
      //yea so no
      /*
      if (gridBased)
      {
         _frameCount++;
         
         if (GameManager.GM.canMove)
         {
            //The smooth movement code now
            if (_gridMoveStart && !_gridMoveCollide)
            {
              
               GameManager.GM.PlayerAnimate("Walk", dir);
               //The thing that makes it nice and smooth
               _smoothMovement = Vector2.SmoothDamp
                  (_smoothMovement, _endMove, ref _smoothMovementVelocity, .125f);
               transform.position = new Vector3(_smoothMovement.x, _smoothMovement.y, _smoothMovement.y);
               _moveTimer += Time.deltaTime;
               
               //The extra time allows it to get closer to the desired end point
               if (_moveTimer >= .19f)
               {
                  _gridMoveStart = false;
                  // Debug.Log("end position = "+transform.position);
                  //This snaps it directly to the grid
                  transform.position = new Vector3(_endMove.x, _endMove.y, 0);
               }
            }
            //This is the code that causes the player to bounce back
            //It's basically the inverse of the grid movement code
            else if (_gridMoveStart && _gridMoveCollide)
            {
               _smoothMovement = Vector2.SmoothDamp
                  (_smoothMovement, _startMove, ref _smoothMovementVelocity, _collideTimer);
               transform.position = new Vector3(_smoothMovement.x, _smoothMovement.y, _smoothMovement.y);
               _moveTimer -= Time.deltaTime;

               if (_moveTimer <= -.65f)
               {
                  _gridMoveStart = false;
                  _gridMoveCollide = false;
                  // Debug.Log("end position = "+transform.position);
                  transform.position = new Vector3(_startMove.x, _startMove.y, 0);
               }
            }
            if (_movementInput != Vector2.zero)
            {
               //if (_frameCount % 6 == 0)
               if (!_gridMoveStart)
               {
                  //The start move is set before anything happens to get the beginning point
                  _startMove = transform.position;
                  //The end move is calculated based on what movement input is given
                  _endMove = new Vector2(_startMove.x+_movementInput.x,_startMove.y+(_movementInput.y/2));
                  //This is to reset all the smooth movement stuff
                  _smoothMovement = _startMove;
                  _moveTimer = 0;
                  _collideTimer = 0;
                  //disable this for player to do some weird drift/jump thing :)
                  _smoothMovementVelocity = Vector2.zero;
                  _gridMoveStart = true;
                  // Debug.Log("end move = "+_endMove);
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
      }*/
      #endregion
   }
   
   void OnMovement(InputValue inputValue)
   {
      //now the input system is all together in 2D movement
      _movementInput = inputValue.Get<Vector2>();
      print(_movementInput);
      
      //ugly please fix iomg
      if (_movementInput.y == 1)
      {
         dir = 'U';
      }
      else if (_movementInput.y == -1)
      {
         dir = 'D';
      }
      else if (_movementInput.x == 1)
      {
         dir = 'R';
      }
      else if (_movementInput.x == -1)
      { 
         dir = 'L';
      }
      
   }

   public void OnTriggerEnter2D(Collider2D other)
   {
      //The funny bounce back only happens if the collision happened to the box collider at the bottom of the player
      if (other.IsTouching(moveCollider))
      {
         Debug.Log(other.gameObject);
         Debug.Log("hi");
         _gridMoveCollide = true;
         _collideTimer = _moveTimer;
      }
   }
}
