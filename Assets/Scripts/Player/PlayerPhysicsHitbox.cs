using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsHitbox : MonoBehaviour
{
    private Collider2D _playerPhysicsHitbox;
    void Start()
    {
        Collider2D parentCollider = GetComponentInParent<Collider2D>();
        _playerPhysicsHitbox = Instantiate(parentCollider, transform.position, Quaternion.identity, transform);
        _playerPhysicsHitbox.isTrigger = false;
    }
}
