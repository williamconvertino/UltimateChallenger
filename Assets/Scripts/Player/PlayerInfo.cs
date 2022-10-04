using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerInfo : MonoBehaviour
    {
        public String playerName = "Player";
        public int playerID = Random.Range(0,1000);
    }
}