using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [Header("Boundaries")] 
    [SerializeField] private Vector2 size;
    [SerializeField] private Vector2 offset;
    public Bounds Bounds => new Bounds(transform.position + new Vector3(offset.x, offset.y), size);
    public Vector2 Center => transform.position;

    private Platform[] _platforms;

    private void Start()
    {
        _platforms = GetComponentsInChildren<Platform>();
    }

    public void TurnOffPlatforms()
    {
        foreach (Platform platform in _platforms)
        {
            platform.gameObject.SetActive(false);
        }
    }

    
    public void TurnOnPlatforms()
    {
        foreach (Platform platform in _platforms)
        {
            platform.gameObject.SetActive(true);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(Bounds.center, Bounds.size);
    }
}
