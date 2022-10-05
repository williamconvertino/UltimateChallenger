using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakePlayerScript : TDChallengePlayerScript
{
    private List<GameObject> _segments;

    private GameObject _segmentPrefab;
    
    private float _segmentTime = 0.1f;
    private float _segmentTimer = 0;

    private float _newSegmentTime = 2.0f;
    private float _newSegmentTimer = 0;

    private BoxCollider2D _playerCollider;

    private bool initialized;

    public bool IsOut { private set; get; } = false;
    private TDPlayerMovement _playerMovement;

    public override void Init()
    {
        base.Init();
        _segments = new List<GameObject>();
        _segmentPrefab = Resources.Load<GameObject>("Prefabs/ChallengeProps/SnakeTrail");
        _playerCollider = GetComponent<BoxCollider2D>();
        _playerMovement = GetComponent<TDPlayerMovement>();
        _recentPlayerDirection = Vector2.up;
        _playerMovement.UseOverrideVelocity = true;
        initialized = true;
    }

    private Vector2 _recentPlayerDirection;
    protected void Update()
    {
        if (_playerMovement.GetRealDirectionX != 0 || _playerMovement.GetRealDirectionY != 0)
        {
            _recentPlayerDirection = new Vector2(_playerMovement.GetRealDirectionX, _playerMovement.GetRealDirectionY);
        }
        
        _playerMovement.OverrideVelocity = new Vector2( _recentPlayerDirection.x , _recentPlayerDirection.y).normalized * _playerMovement.speedScale;
        
        if (_newSegmentTimer > 0)
        {
            _newSegmentTimer -= Time.deltaTime;
        }
        else
        {
            Vector3 position = _segments.Count > 0 ? _segments[0].transform.position : transform.position;
            GameObject segment = Instantiate(_segmentPrefab, position, Quaternion.identity);
            segment.GetComponent<SnakeSegmentScript>().Init(gameObject);
            SpriteRenderer segmentRenderer = segment.GetComponent<SpriteRenderer>();
            segmentRenderer.color = GetComponent<SpriteRenderer>().color;
            segmentRenderer.size = _playerCollider.size / 4;
            
            _segments.Add(segment);
            _newSegmentTimer = _newSegmentTime;
        }

        if (_segmentTimer > 0)
        {
            _segmentTimer -= Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < _segments.Count; i++)
            {
                Vector3 position = i + 1 < _segments.Count ? _segments[i + 1].transform.position : transform.position;
                _segments[i].transform.position = position;
            }   
            _segmentTimer = _segmentTime;
        }

    }
    
    public void Hit()
    {
        IsOut = true;
        gameObject.SetActive(false);
        foreach (GameObject segment in _segments)
        {
            Destroy(segment);
        }
    }
    
    
    public override void Cleanup()
    {
        
        _playerMovement.UseOverrideVelocity = false;
        gameObject.SetActive(true);
        foreach (GameObject segment in _segments)
        {
            Destroy(segment);
        }
    }
}