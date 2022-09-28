using System;
using UnityEngine;
using System.Collections;
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

    #endregion

    #region Cleanup
    protected virtual void Cleanup()
    {
        if (!_usedPlayerScripts)
        {
            return;
        }
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
    #endregion
}
