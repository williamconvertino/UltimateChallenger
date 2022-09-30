using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInput : MonoBehaviour
{
    public abstract MovementInput GetInput();
    public abstract TDMovementInput GetTDInput();

    public struct MovementInput
    {
        public float DirX;
        public bool DoJump;
    }
    public struct TDMovementInput
    {
        public float DirX;
        public float DirY;
    }
}
