using System;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private String playerName = "Player";

    public String GetPlayerName() => playerName;
}
