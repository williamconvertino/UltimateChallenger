using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tag : TimedChallenge
{
    private void Start()
    {
        Console.WriteLine("Starting Tag");
        foreach (GameObject player in Players)
        {
            player.AddComponent<TagPlayerScript>();
        }
        
        TagPlayerScript initialTagger = Players[Random.Range(0, Players.Length)].GetComponent<TagPlayerScript>();
        initialTagger.Tag();
    }

    protected override void Cleanup()
    {
        foreach (GameObject player in Players)
        {
            if (player.GetComponent<TagPlayerScript>().Tagged)
            {
                Console.WriteLine(player + " Loses");
            }
            Destroy(player.GetComponent<TagPlayerScript>());
        }
    }
}