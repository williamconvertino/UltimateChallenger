using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JILKInput : PlayerInput
{
    public override MovementInput GetInput()
    {
        return new MovementInput()
        {
            DirX = (Input.GetKey(KeyCode.J) ? -1.0f : 0) + (Input.GetKey(KeyCode.L) ? 1.0f : 0),
            DoJump = Input.GetKeyDown(KeyCode.I)
        };
    }
}
