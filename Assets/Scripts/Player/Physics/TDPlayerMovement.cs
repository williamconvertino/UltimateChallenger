using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.Serialization;

public class TDPlayerMovement : MonoBehaviour
{
    
    #region Core
    [Header("Interaction Masks")]
    [SerializeField] private LayerMask solidLayerMask;
    
    private Rigidbody2D _rb2d;
    private BoxCollider2D _boxCollider;
    private PlayerInput _playerInput;
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        GetInput();
        Move();
    }
    
    #endregion

    #region Movement
    [Header("Movement")]
    [SerializeField] private float speedScale = 6.0f;

    private Vector2 _velocity = Vector2.zero;
    public Vector2 GetVelocity => _velocity;
    private int _directionX = 1;
    private int _directionY = 1;
    public int GetDirectionX => _directionX;
    public int GetDirectionY => _directionY;
    private PlayerInput.TDMovementInput _input;
    
    //Moves the player according to physics and their input.
    private void Move()
    {
        _velocity = new Vector2(_input.DirX, _input.DirY).normalized * speedScale;

        if (_input.DirX > 0)
        {
            _directionX = 1;
        }
        if (_input.DirX < 0)
        {
            _directionX = -1;
        }
        
        if (_input.DirY > 0)
        {
            _directionY = 1;
        }
        if (_input.DirY < 0)
        {
            _directionY = -1;
        }

        _rb2d.velocity = new Vector2(_velocity.x, _velocity.y);
    }
    
    #endregion
    
    #region Input
    
    //Gets the player's current input.
    private void GetInput()
    {
        _input = _playerInput.GetTDInput();
    }
    
    //A struct for storing the player's input.
    

    #endregion
    
    #region Gizmos
    private void OnDrawGizmos()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        Bounds bounds = _boxCollider.bounds;
        float detectorStartX = bounds.min.x;
        float detectorEndX = bounds.max.x;
        float detectorYTop = bounds.max.y;
        float detectorYBottom = bounds.min.y;
        
    }
    #endregion
}