﻿using UnityEngine;

namespace Minigames
{
    public abstract class Minigame : MonoBehaviour
    {
        public abstract void Initialize(GameObject[] players);
    }
}