using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Challenge : MonoBehaviour
{
    public bool IsChallengeOver { protected set; get; } = false;

    #region Initialization
    protected GameObject[] Players;
    private Stage _stage;
    public virtual void Init(GameObject[] players, Stage stage)
    
    {
        Players = players;
        _stage = stage;
    }

    protected Action<Stage> _setStage;
    protected Action _resetStage;
    public virtual void InitStageHandlers(Action<Stage> setStage, Action resetStage)
    {
        _setStage = setStage;
        _resetStage = resetStage;
    }
    #endregion

    #region Victory

    protected abstract void CheckVictory();
    
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
    protected List<T> AddScriptToPlayers<T> () where T : ChallengePlayerScript
    {
        List<T> playerScripts = new List<T>();
        foreach (GameObject player in Players)
        {
            T playerScript = player.AddComponent<T>();
            playerScript.Init();
            playerScripts.Add(playerScript);
        }
        _usedPlayerScripts = true;
        return playerScripts;
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

    #region On Respawn

    public virtual void OnPlayerRespawn(GameObject player)
    {
        
    } 

    #endregion
    
    #region Cleanup
    //Removes all the challenge scripts on players.
    public virtual void Cleanup()
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
