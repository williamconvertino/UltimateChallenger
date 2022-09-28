using UnityEngine;

namespace Player
{
    public abstract class PlayerScore : MonoBehaviour
    {
        public abstract bool WinRound();
        public abstract bool LoseRound();
    }
}