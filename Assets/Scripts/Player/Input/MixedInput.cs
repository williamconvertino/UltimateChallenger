using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedInput : PlayerInput
{
    public override MovementInput GetInput()
    {
        return new MovementInput()
        {
            DirX = Input.GetAxis("Horizontal"),
            DoJump = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)|| Input.GetButton("Jump")
        };
    }
}
