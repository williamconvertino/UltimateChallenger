﻿using System.Collections.Generic;
using UnityEngine;

namespace Player.Input.ButtonPress
{
    public class SplitKeyboardLeftButtonPress : ButtonPress
    {
        protected override void PopulateKeyCodeList()
        {
            KeyCodeList = new KeyCode[]
            {
                KeyCode.LeftShift,
                KeyCode.LeftCommand,
                KeyCode.Tab,
                KeyCode.CapsLock
            } ;
        }
    }
}