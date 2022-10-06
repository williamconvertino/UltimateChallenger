using System;
using System.Collections.Generic;
using UnityEngine;

public class HopperChallenge : Challenge
{
    private List<HopperPlayerScript> _playerScripts;
    
    private float _setTime = 3.0f;
    private float _setTimer;

    [SerializeField] private GameObject stagePrefab;
    private Stage _hopperStage;
    
    private GameObject _setBase;
    private List<GameObject> _sets;

    public override void Init(GameObject[] players, Stage stage)
    {
        base.Init(players, stage);
        _playerScripts = AddScriptToPlayers<HopperPlayerScript>();
        _hopperStage = Instantiate(stagePrefab).GetComponent<Stage>();
        _setStage(_hopperStage);
        _sets = new List<GameObject>();
        
        foreach(Transform tr in _hopperStage.gameObject.transform)
        {
            GameObject child = tr.gameObject;
            if(child.CompareTag("HopperBase"))
            {
                _setBase = child;
            }

            if (child.CompareTag("HopperSet"))
            {
                _sets.Add(child);
            }
        }

        _currentSet = _setBase;
        _setTimer = _setTime;
    }

    private int numSets = 0;
    private float _timerDrop = 1f;
    private void Update()
    {
        CheckVictory();
        if (_setTimer > 0)
        {
            _setTimer -= Time.deltaTime;
            return;
        }

        
        numSets++;
        if (numSets % _sets.Count == 0 && _setTime - _timerDrop >= 0.5f)
        {
            _setTime -= _timerDrop;
        }

        _setTimer = _setTime;
        SwitchSet();
    }

    private int setIndex = 0;
    private GameObject _previousSet;
    private GameObject _currentSet;
    private void SwitchSet()
    {
        if (_previousSet != null)
        {
            _previousSet.SetActive(false);
        }

        _previousSet = _currentSet;
        _currentSet = _sets[setIndex];
        _currentSet.SetActive(true);
        setIndex = (setIndex + 1) % _sets.Count;
    }

    public override void OnPlayerRespawn(GameObject player)
    {
        base.OnPlayerRespawn(player);
        player.GetComponent<HopperPlayerScript>().Hit();
    }

    protected override void CheckVictory()
    {
        int numActive = 0;
        foreach (HopperPlayerScript playerScript in _playerScripts)
        {
            if (!playerScript.playerIsOut)
            {
                numActive++;
            }
        }

        if (numActive <= 1)
        {
            IsChallengeOver = true;
        }
    }
    
    public override GameObject[] GetWinners()
    {
        List<GameObject> winners = new List<GameObject>();
        foreach (HopperPlayerScript playerScript in _playerScripts)
        {
            if (!playerScript.playerIsOut)
            {
                winners.Add(playerScript.Player);
            }
        }

        return winners.ToArray();
    }
    public override GameObject[] GetLosers()
    {
        List<GameObject> losers = new List<GameObject>();
        foreach (HopperPlayerScript playerScript in _playerScripts)
        {
            if (playerScript.playerIsOut)
            {
                losers.Add(playerScript.Player);
            }
        }

        return losers.ToArray();
    }

    public override void Cleanup()
    {
        base.Cleanup();
        _resetStage();
        foreach (GameObject set in _sets)
        {
            set.SetActive(false);
            Destroy(set);
        }
    }
}