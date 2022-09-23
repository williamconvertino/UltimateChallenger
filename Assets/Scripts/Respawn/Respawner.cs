using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Respawner : MonoBehaviour
{
    public float width, height;

    public Vector2 GetUsableLocation()
    {
        return transform.position + Vector3.up * 0.5f ;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}
