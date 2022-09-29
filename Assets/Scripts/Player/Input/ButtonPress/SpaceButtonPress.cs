using System.Collections.Generic;
using UnityEngine;

namespace Player.Input.ButtonPress
{
    public class SpaceButtonPress : ButtonPress
    {
        protected override void PopulateKeyCodeList()
        {
            KeyCodeList = new KeyCode[]
            {
                KeyCode.Space
            } ;
        }
    }
}