using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakePlayerScript : TDChallengePlayerScript
{
    private List<GameObject> _segments;

    private GameObject _segmentPrefab;
    
    private float _segmentTime = 3.0f;
    private float _segmentTimer = 0;

    private bool initialized;
    public override void Init()
    {
        base.Init();
        _segments = new List<GameObject>();
        _segmentPrefab = Resources.Load<GameObject>("Prefabs/ChallengeProps/SnakeTrail");
        BoxCollider2D playerCollider = GetComponent<BoxCollider2D>();
        playerCollider.GetComponent<SpriteRenderer>().size = playerCollider.bounds.size;
        initialized = true;
    }
    protected void Update()
    {
        if (!initialized)
        {
            return;
        }
        if (_segmentTimer > 0)
        {
            _segmentTimer -= Time.deltaTime;
            return;
        }

        Instantiate(_segmentPrefab, transform.position, Quaternion.identity, transform);
        _segmentTimer = _segmentTime;
    }
}