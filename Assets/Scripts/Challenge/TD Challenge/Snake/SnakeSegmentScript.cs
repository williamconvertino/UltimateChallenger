using UnityEngine;

public class SnakeSegmentScript : MonoBehaviour
{
    private GameObject _hostPlayer;
    
    public void Init(GameObject player)
    {
        _hostPlayer = player;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.gameObject != _hostPlayer)
        {
            col.gameObject.GetComponent<SnakePlayerScript>().Hit();
        }
    }
}