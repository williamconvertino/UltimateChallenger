using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakePlayerScript : TDChallengePlayerScript
{
    private List<GameObject> _segments;

    private GameObject _segmentPrefab;
    
    private float _segmentTime = 1.0f;
    private float _segmentTimer = 0;

    public override void Init()
    {
        _segments = new List<GameObject>();
        _segmentPrefab = new GameObject();
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Rect segmentRect = new Rect();
        _segmentPrefab.AddComponent<SpriteRenderer>().sprite = Sprite.Create(Texture2D.normalTexture,segmentRect, Vector2.zero);
    }
    protected void Update()
    {
        if (_segmentTimer > 0)
        {
            _segmentTimer -= Time.deltaTime;
            return;
        }

        Instantiate(_segmentPrefab, transform.position, Quaternion.identity);
        _segmentTimer = _segmentTime;
    }
}