using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInput : MonoBehaviour
{
    public abstract MovementInput GetInput();

    public struct MovementInput
    {
        public float DirX;
        public bool DoJump;
    }
}
