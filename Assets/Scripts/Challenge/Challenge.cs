using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Challenge : MonoBehaviour
{
    public bool IsChallengeOver { protected set; get; } = false;

    #region Initialization
    [SerializeField] private GameObject[] playerScriptPrefabs;
    protected GameObject[] Players;
    public virtual void Init(GameObject[] players)
    
    {
        Players = players;
    }
    #endregion

    #region Victory

    public virtual GameObject[] GetWinners()
    {
        return new GameObject[0];
    }
    public virtual GameObject[] GetLosers()
    {
        return new GameObject[0];
    }

    #endregion
    
    #region Player Scripts

    private bool _usedPlayerScripts = false;
    protected void AddScriptToPlayer<T> (GameObject player) where T : ChallengePlayerScript
    {
        player.AddComponent<T>().Init();
        _usedPlayerScripts = true;
    }
    protected void AddScriptToPlayers<T> () where T : ChallengePlayerScript
    {
        foreach (GameObject player in Players)
        {
            player.AddComponent<T>().Init();
        }

        _usedPlayerScripts = true;
    }

    
    //Returns all the challenge scripts of the specified type on every player.
    protected List<T> GetPlayerScripts<T>() where T : ChallengePlayerScript
    {
        List<T> scriptList = new List<T>();
        foreach (GameObject player in Players)
        {
            T playerScript = player.GetComponent<T>();
            if (playerScript != null)
            {
                scriptList.Add(playerScript);
            }
        }

        return scriptList;
    }
    
    //Returns all the challenge scripts on every player.
    protected List<ChallengePlayerScript> GetAllPlayerScripts()
    {
        List<ChallengePlayerScript> scriptList = new List<ChallengePlayerScript>();
        foreach (GameObject player in Players)
        {
            scriptList.AddRange(player.GetComponents<ChallengePlayerScript>());
        }
        return scriptList;
    }

    #endregion

    #region Cleanup
    //Removes all the challenge scripts on players.
    protected virtual void Cleanup()
    {
        if (!_usedPlayerScripts)
        {
            return;
        }

        foreach (ChallengePlayerScript playerScript in GetAllPlayerScripts())
        {
            playerScript.Cleanup();
            Destroy(playerScript);
        }
    }
    #endregion
}
