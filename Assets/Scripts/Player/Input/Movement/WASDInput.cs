using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDInput : PlayerInput
{
    public override MovementInput GetInput()
    {
        return new MovementInput()
        {
            DirX = (Input.GetKey(KeyCode.A) ? -1.0f : 0) + (Input.GetKey(KeyCode.D) ? 1.0f : 0),
            DoJump = Input.GetKeyDown(KeyCode.W)
        };
    }
}
