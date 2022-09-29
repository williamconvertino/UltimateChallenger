using System;
using UnityEngine;

public class CrownPlayerScript : ChallengePlayerScript
{
    public bool Crowned { private set; get; }  = false;
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
        if (Crowned)
        {
            bool crownSuccessful = other.GetComponent<CrownPlayerScript>().Crown();
            if (crownSuccessful)
            {
                UnCrown();
            }
        }
    }

    public void UnCrown()
    {
        Crowned = false;
        _invincibilityTimer = _totalInvincibilityTime;
        _spriteRenderer.color = _originalColor;
    }

    public bool Crown()
    {
        if (_invincibilityTimer > 0)
        {
            return false;
        }
        _spriteRenderer.color = Color.yellow;
        return Crowned = true;
    }

    public override void Cleanup()
    {
        UnCrown();
    }
}
