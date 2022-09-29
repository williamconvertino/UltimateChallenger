using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowInput : PlayerInput
{

    public override MovementInput GetInput()
    {
        return new MovementInput()
        {
            DirX = (Input.GetKey(KeyCode.LeftArrow) ? -1.0f : 0) + (Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0),
            DoJump = Input.GetKeyDown(KeyCode.UpArrow)
        };
    }
}
