using System;
using UnityEngine;
using System.Collections;
public abstract class Challenge : MonoBehaviour
{
    [SerializeField] private GameObject[] playerScriptPrefabs;
    public bool IsChallengeOver { protected set; get; } = false;
    protected GameObject[] Players;
    public virtual void Init(GameObject[] players)
    {
        Players = players;
    }

    protected void AddScriptToPlayers<T> () where T : ChallengePlayerScript
    {
        foreach (GameObject player in Players)
        {
            player.AddComponent<T>();
        }   
    }
    protected virtual void Cleanup()
    {
        foreach (GameObject player in Players)
        {
            ChallengePlayerScript[] allPlayerScripts = player.GetComponents<ChallengePlayerScript>();
            if (allPlayerScripts.Length > 0)
            {
                foreach (ChallengePlayerScript playerScript in allPlayerScripts)
                {
                    playerScript.Cleanup();
                    Destroy(playerScript);   
                }   
            }
        }
    }
}
