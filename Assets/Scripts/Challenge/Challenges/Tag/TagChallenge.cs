using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class TagChallenge : TimedChallenge
{
    public override void Init(GameObject[] players)
    {
        base.Init(players);
        AddScriptToPlayers<TagPlayerScript>();
        TagPlayerScript initialTagger = Players[Random.Range(0, Players.Length)].GetComponent<TagPlayerScript>();
        initialTagger.Tag();
    }

    protected override void Cleanup()
    {
        base.Cleanup();
        
    }
}