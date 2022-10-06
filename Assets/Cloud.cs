using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    [SerializeField] private Sprite[] possibleClouds;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = possibleClouds[Random.Range(0, possibleClouds.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
