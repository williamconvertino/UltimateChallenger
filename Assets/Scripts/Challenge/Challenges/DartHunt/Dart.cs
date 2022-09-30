using System;
using Unity.VisualScripting;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] private float dartSpeed;

    public bool DartHit { private set; get; } = false;
    public float GetDartSpeed => dartSpeed;
    private Rigidbody2D _rb2d;
    private GameObject _hostPlayer;
    public void Init(GameObject player)
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _hostPlayer = player;
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rb2d.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.gameObject != _hostPlayer)
        {
            DartHit = true;
            col.gameObject.GetComponent<DartHuntPlayerScript>().Hit();
        }

        if (col.CompareTag("Environment"))
        {
            DartHit = true;
        }
    }
}
