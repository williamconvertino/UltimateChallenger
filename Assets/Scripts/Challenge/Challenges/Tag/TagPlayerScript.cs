using System;
using UnityEngine;

public class TagPlayerScript : MonoBehaviour
{
    public bool Tagged { private set; get; } = false;
    private float _totalInvincibilityTime = 2.0f;
    private float _invincibilityTimer = 0;

    private void Update()
    {
        if (_invincibilityTimer > 0)
        {
            _invincibilityTimer -= Time.deltaTime;    
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     GameObject otherPlayer = collision.gameObject;
    //     if (Tagged && otherPlayer != null && collision.gameObject.CompareTag("Player"))
    //     {
    //         bool tagSuccessful = otherPlayer.GetComponent<TagPlayerScript>().Tag();
    //
    //         if (tagSuccessful)
    //         {
    //             UnTag();
    //         }
    //     }
    // }

    private void UnTag()
    {
        Tagged = false;
        _invincibilityTimer = _totalInvincibilityTime;
    }

    public bool Tag()
    {
        return Tagged = _invincibilityTimer <= 0;
    }
}
