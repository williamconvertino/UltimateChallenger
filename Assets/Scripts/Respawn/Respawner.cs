using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Respawner : MonoBehaviour
{
    public float width, height;

    public Vector2 GetUsableLocation()
    {
        float wb2 = width / 2.0f;
        Vector2 position = transform.position;
        return new Vector2(position.x + Random.Range(-wb2, wb2), position.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}
