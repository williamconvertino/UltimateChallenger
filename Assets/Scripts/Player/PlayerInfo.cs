using System;
using UnityEngine;

namespace Player
{
    public class PlayerInfo : MonoBehaviour
    {
        public String Name { private set; get;}

        public void Init(String name)
        {
            Name = name;
        }
    }
}