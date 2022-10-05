using System;
using UnityEngine;

public class TagPlayerScript : ChallengePlayerScript
{
    public bool Tagged { private set; get; }  = false;
    private float _totalInvincibilityTime = 0.5f;
    private float _invincibilityTimer = 0;

    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    public override void Init()
    {
        base.Init();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }
    private void Update()
    {
        if (_invincibilityTimer > 0)
        {
            _invincibilityTimer -= Time.deltaTime;    
        }
    }

    public override void OnPlayerCollision(GameObject other)
    {
        if (Tagged)
        {
            bool tagSuccessful = other.GetComponent<TagPlayerScript>().Tag();
            if (tagSuccessful)
            {
                UnTag();
            }
        }
    }

    public void UnTag()
    {
        Tagged = false;
        _invincibilityTimer = _totalInvincibilityTime;
        _spriteRenderer.color = _originalColor;
    }

    public bool Tag()
    {
        if (_invincibilityTimer > 0)
        {
            return false;
        }
        _spriteRenderer.color = Color.black;
        
        return Tagged = true;
    }

    public override void Cleanup()
    {
        UnTag();
    }
}
