using System;
using System.Collections.Generic;
using UnityEngine;

public class RPSPlayerScript : ChallengePlayerScript
{
    public bool PlayerHit { private set; get; } = false;
    public float NumHits { private set; get; } = 0;

    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    private Color _teamColor;
    public override void Init()
    {
        base.Init();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }

    public RPSChallenge.RPSTeam Team { private set; get; }

    public void SetTeam(RPSChallenge.RPSTeam team)
    {
        Team = team;
        _originalColor = _spriteRenderer.color;
        if (team == RPSChallenge.RPSTeam.Rock)
        {
            _spriteRenderer.color = _teamColor = Color.black;
        }
        if (team == RPSChallenge.RPSTeam.Paper)
        {
            _spriteRenderer.color = _teamColor = Color.white;
        }
        if (team == RPSChallenge.RPSTeam.Scissors)
        {
            _spriteRenderer.color =_teamColor = Color.gray;
        }
    }

    private Action _addScoreFunction;
    public void SetAddScoreFunction(Action addScoreFunction)
    {
        _addScoreFunction = addScoreFunction;
    }

    private void Update()
    {
        if (_invincibilityTimer > 0)
        {
            _invincibilityTimer -= Time.deltaTime;
        }
        else
        {
            _spriteRenderer.color = _teamColor;
        }
    }

    private float _invincibilityTime = 1.5f;
    private float _invincibilityTimer = 0;
    public bool Hit()
    {
        if (_invincibilityTimer > 0)
        {
            return false;
        }
        
        _spriteRenderer.color = Color.red;
        _invincibilityTimer = _invincibilityTime;
        return true;
    }

    private Dictionary<RPSChallenge.RPSTeam, RPSChallenge.RPSTeam> _target =
        new Dictionary<RPSChallenge.RPSTeam, RPSChallenge.RPSTeam>()
        {
            {RPSChallenge.RPSTeam.Rock, RPSChallenge.RPSTeam.Scissors},
            {RPSChallenge.RPSTeam.Scissors, RPSChallenge.RPSTeam.Paper},
            {RPSChallenge.RPSTeam.Paper, RPSChallenge.RPSTeam.Rock}
            
        };
    public override void OnPlayerCollision(GameObject player)
    {
        RPSPlayerScript otherScript = player.GetComponent<RPSPlayerScript>();
        RPSChallenge.RPSTeam otherTeam = otherScript.Team;
        if (_invincibilityTimer <= 0 && _target[Team] == otherTeam && otherScript.Hit())
        {
            _addScoreFunction();
        }
    }

    public override void Cleanup()
    {
        _spriteRenderer.color = _originalColor;
    }
}
