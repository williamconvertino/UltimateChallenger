using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Player.Input.ButtonPress;
using UnityEngine;
using UnityEngine.UIElements;

public class DartHuntPlayerScript : ChallengePlayerScript
{
    public bool PlayerHit { private set; get; } = false;
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovementScript;
    
    public override void Init()
    {
        base.Init();
        _playerInput = GetComponent<PlayerInput>();
        _playerMovementScript = GetComponent<PlayerMovement>();
        _dartPrefab = Resources.Load<GameObject>("Prefabs/ChallengeProps/Dart");
    }

    private Func<GameObject, bool> _spawnDartFunction;
    public void SetSpawnDartFunction(Func<GameObject, bool> spawnDartFunction)
    {
        _spawnDartFunction = spawnDartFunction;
    }
    
    private void Update()
    {
        if (_shootTimer > 0)
        {
            _shootTimer -= Time.deltaTime;
        }
        if (_playerInput.ButtonPressed())
        {
            ShootDart();
        }
    }


    [Header("Dart Properties")]
    private GameObject _dartPrefab;

    private float shootDelay = 1.0f;
    private float _shootTimer = 0;
    private void ShootDart()
    {
        if (_shootTimer > 0)
        {
            return;
        }

        GameObject dart = Instantiate(_dartPrefab, transform.position, Quaternion.identity);
        Dart dartScript = dart.GetComponent<Dart>();
        dartScript.Init(gameObject);

        int playerDirection = _playerMovementScript.GetDirectionX;
        
        dartScript.SetVelocity( new Vector2(playerDirection, 0).normalized * dartScript.GetDartSpeed);
        _spawnDartFunction(dart);
        _shootTimer = shootDelay;
    }

    public void Hit()
    {
        gameObject.SetActive(false);
        PlayerHit = true;
    }
    
    

    public override void Cleanup()
    {
        gameObject.SetActive(true);
    }
}
