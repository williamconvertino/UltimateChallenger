using System.Collections.Generic;
using UnityEngine;

namespace Player.Input.ButtonPress
{
    public class SplitKeyboardRightButtonPress : ButtonPress
    {
        protected override void PopulateKeyCodeList()
        {
            KeyCodeList = new KeyCode[]
            {
                KeyCode.RightShift,
                KeyCode.RightAlt,
                KeyCode.Space,
                KeyCode.Slash,
                KeyCode.Period,
                KeyCode.Comma,
                KeyCode.M,
                KeyCode.N,
                KeyCode.Return,
                KeyCode.Quote,
                KeyCode.Semicolon,
                KeyCode.L,
                KeyCode.K,
                KeyCode.J,
                KeyCode.P,
                KeyCode.O,
                KeyCode.I,
                KeyCode.U,
                KeyCode.Y,
                KeyCode.H,
                KeyCode.B
            } ;
        }
    }
}